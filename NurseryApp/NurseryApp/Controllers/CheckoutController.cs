using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckoutController(UserManager<ApplicationUser> userManager, ICheckout context, IBasketProduct basketProduct, IBasket basketcontext, ICheckoutProduct checkoutProduct, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _basketcontext = basketcontext;
            _basketProduct = basketProduct;
            _checkoutProduct = checkoutProduct;
            _emailSender = emailSender;
        }

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
                checkout.UserID = userID;
                await _context.CreateCheckoutAsync(checkout);
                foreach (var bp in basketProducts)
                {
                    await _checkoutProduct.AddCheckoutProduct(bp.ProductID, bp.Quantity, checkout.ID);
                    bp.BasketID = checkout.ID;
                    checkout.Total += Convert.ToDecimal(bp.Quantity) * bp.Price;
                }

            CheckoutViewModel checkoutVM = new CheckoutViewModel()
            {
                Name = User.Claims.First(name => name.Type == "FullName").Value,
                Email = userEmail,
                Address = userRaw.Address,
                City = userRaw.City,
                State = userRaw.State,
                ZipCode = userRaw.ZipCode,
                Total = checkout.Total,
            };
            return View(checkoutVM);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel cvm)
        {
            string userEmail = User.Identity.Name;
            var userRaw = await _userManager.FindByEmailAsync(userEmail);
            userRaw.Address = cvm.Address;
            userRaw.State = cvm.State;
            userRaw.City = cvm.City;
            userRaw.ZipCode = cvm.ZipCode;
            await _userManager.UpdateAsync(userRaw);

            //TO-DO: Incorportate Auth.Net Processesing

            return RedirectToAction("Receipt");
        }

        /// <summary>
        /// Creates a receipt of a user's basket contents, takes the user to a view displaying the receipt, and emails them an invoice.
        /// </summary>
        /// <returns>Receipt view with ordered products</returns>
        [Authorize]
        public async Task<IActionResult> Receipt()
        {
            string userEmail = User.Identity.Name;
            var userRaw = await _userManager.FindByEmailAsync(userEmail);
            string userID = userRaw.Id;
            
            Basket basket = await _basketcontext.GetBasketByUserId(userID);
            List<BasketProductViewModel> basketProducts =  await _basketProduct.GetBasket(basket.ID);

            Checkout checkout = await _context.GetCheckoutByUserId(userID);
 

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
            foreach (BasketProductViewModel item in basketProducts)
            {
                invoice.AppendLine("<tr>");
                invoice.AppendLine($"<td>{item.Name}</td><td>{item.Quantity}</td><td>${item.Price * item.Quantity}</td>");
                invoice.AppendLine("</tr>");
            }
            invoice.AppendLine("</tbody>");
            invoice.AppendLine("</table>");
            invoice.AppendLine("<hr>");
            invoice.AppendLine($"<h2>Total: ${basketProducts[0].Total}</h2>");

            await _emailSender.SendEmailAsync(userEmail, "Order Confirmed", invoice.ToString());

            return View(basketProducts);
        }
    }
}
