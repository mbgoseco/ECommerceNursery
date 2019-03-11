using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NurseryApp.Models;
using NurseryApp.Models.Interfaces;
using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryApp.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICheckout _context;
        private readonly IBasket _basketcontext;
        private readonly IBasketProduct _basketProduct;
        private readonly ICheckoutProduct _checkoutProduct;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Constructor method that brings in services to be used by the CheckoutController
        /// </summary>
        /// <param name="userManager">UserManager service</param>
        /// <param name="context">Checkout interface</param>
        /// <param name="basketProduct">BasketProduct interface</param>
        /// <param name="basketcontext">Basket interface</param>
        /// <param name="checkoutProduct">CheckoutProduct interface</param>
        /// <param name="emailSender">EmailSender interface</param>
        /// <param name="configuration">Configuration strings from user secrets</param>
        public CheckoutController(UserManager<ApplicationUser> userManager, ICheckout context, IBasketProduct basketProduct, IBasket basketcontext, ICheckoutProduct checkoutProduct, IEmailSender emailSender, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _basketcontext = basketcontext;
            _basketProduct = basketProduct;
            _checkoutProduct = checkoutProduct;
            _emailSender = emailSender;
            _configuration = configuration;
        }

        /// <summary>
        /// Creates a checkout instance of the user's current basket items and takes them to the checkout view to fill out the form to complete the checkout process.
        /// </summary>
        /// <returns>View of checkout page</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            string userEmail = User.Identity.Name;
            var userRaw = await _userManager.FindByEmailAsync(userEmail);
            string userID = userRaw.Id;

            Basket basket = await _basketcontext.GetBasketByUserId(userID);
            List<BasketProductViewModel> basketProducts = await _basketProduct.GetBasket(basket.ID);

            Checkout checkout = new Checkout();
            checkout.UserID = userEmail;
            checkout.Name = User.Claims.First(name => name.Type == "FullName").Value;
            checkout.OrderDate = DateTime.Now;
            await _context.CreateCheckoutAsync(checkout);
            foreach (var bp in basketProducts)
            {
                await _checkoutProduct.AddCheckoutProduct(bp.ProductID, bp.Quantity, checkout.ID);
                bp.BasketID = checkout.ID;
                checkout.Total += Convert.ToDecimal(bp.Quantity) * bp.Price;
                await _context.UpdateCheckoutAsync(checkout);
            }

            CheckoutViewModel checkoutVM = new CheckoutViewModel()
            {
                ID = checkout.ID,
                Name = checkout.Name,
                Email = userEmail,
                Address = userRaw.Address,
                City = userRaw.City,
                State = userRaw.State,
                ZipCode = userRaw.ZipCode,
                OrderDate = checkout.OrderDate,
                Total = checkout.Total,
            };
            return View(checkoutVM);
        }

        /// <summary>
        /// Takes the user's checkout information from the form and sends it to the third party payment authorization service. If the payment is successful the basket is emptied, and user is sent to a receipt page. If not successful, the user is returned to the checkout form.
        /// </summary>
        /// <param name="cvm">Checkout View Model with user's checkout info</param>
        /// <returns>Receipt view or return to Checkout view</returns>
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel cvm)
        {
            Checkout checkout = await _context.GetCheckoutByUserId(cvm.Email, cvm.ID);
            checkout.Address = cvm.Address;
            checkout.City = cvm.City;
            checkout.State = cvm.State;
            checkout.ZipCode = cvm.ZipCode;

            string userEmail = User.Identity.Name;
            var userRaw = await _userManager.FindByEmailAsync(userEmail);
            userRaw.Address = cvm.Address;
            userRaw.State = cvm.State;
            userRaw.City = cvm.City;
            userRaw.ZipCode = cvm.ZipCode;
            await _userManager.UpdateAsync(userRaw);

            Payment payment = new Payment(_configuration);
            string response = payment.Run(cvm);
            if (response == "Payment Successful")
            {
                Basket basket = await _basketcontext.GetBasketByUserId(userRaw.Id);
                var basketProducts = await _basketProduct.GetBasket(basket.ID);
                foreach (var product in basketProducts)
                {
                    await _basketProduct.DeleteBasketProductByID(basket.ID, product.ProductID);
                }
                return Redirect($"Receipt/{cvm.ID}");
            }
            else
            {
                return View(cvm);
            }

        }

        /// <summary>
        /// Creates a receipt of a user's basket contents, takes the user to a view displaying the receipt, and emails them an invoice.
        /// </summary>
        /// <returns>Receipt view with ordered products</returns>
        [Authorize]
        public async Task<IActionResult> Receipt(int id)
        {
            string userEmail = User.Identity.Name;
            var userRaw = await _userManager.FindByEmailAsync(userEmail);
            string userID = userRaw.Id;
            
            Checkout checkout = await _context.GetCheckoutByUserId(userEmail, id);
            List<BasketProductViewModel> checkoutProducts = await _checkoutProduct.GetCheckout(checkout.ID);
            foreach (var checkoutProduct in checkoutProducts)
            {
                checkoutProduct.ProductTotal = checkoutProduct.Price * checkoutProduct.Quantity;
                checkoutProduct.Total = checkout.Total;
            }
 

            StringBuilder invoice = new StringBuilder();

            invoice.AppendLine("<h1>Your order has been placed!</h1>");
            invoice.AppendLine("<hr>");
            invoice.AppendLine("<table>");
            invoice.AppendLine("<thead>" +
                "<tr>" +
                "<th>Item</th>" +
                "<th>Quantity</th>" +
                "<th>Price</th>" +
                "</tr>" +
                "</thead>");
            invoice.AppendLine("<tbody>");
            foreach (BasketProductViewModel item in checkoutProducts)
            {
                invoice.AppendLine("<tr>");
                invoice.AppendLine($"<td>{item.Name}</td><td>{item.Quantity}</td><td>${item.Price * item.Quantity}</td>");
                invoice.AppendLine("</tr>");
            }
            invoice.AppendLine("</tbody>");
            invoice.AppendLine("</table>");
            invoice.AppendLine("<hr>");
            invoice.AppendLine($"<h2>Total: ${checkoutProducts[0].Total}</h2>");

            await _emailSender.SendEmailAsync(userEmail, "Order Confirmed", invoice.ToString());

            return View(checkoutProducts);
        }
    }
}
