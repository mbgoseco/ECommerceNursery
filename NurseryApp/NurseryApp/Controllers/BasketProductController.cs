using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NurseryApp.Data;
using NurseryApp.Models;
using NurseryApp.Models.Interfaces;
using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Controllers
{
    public class BasketProductController : Controller
    {
        private readonly IBasketProduct _basketProduct;
        private readonly IBasket _basket;

        private readonly UserManager<ApplicationUser> _userManager;


        public BasketProductController(IBasketProduct basketProduct, IBasket basket, UserManager<ApplicationUser> userManager)
        {
            _basketProduct = basketProduct;
            _basket = basket;
            _userManager = userManager;
        }

        /// <summary>
        /// Takes user to the basket page showing items in their basket
        /// </summary>
        /// <returns>Basket page</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userEmail = User.Identity.Name;
            var userRaw = await _userManager.FindByEmailAsync(userEmail);
            string userID = userRaw.Id;
            var basket = await _basket.GetBasketByUserId(userID);

            var products = await _basketProduct.GetBasket(basket.ID);

            return View(products);
        }

        /// <summary>
        /// Takes a product ID and quantity from the view form and gives it to AddBasketProduct service
        /// </summary>
        /// <param name="id">Primary Key value</param>
        /// <param name="quantity">Quantity of product</param>
        /// <returns>View of user's basket with added product</returns>
        [HttpPost]
        public async Task<IActionResult> Add(int id, int quantity)
        {
            string userEmail = User.Identity.Name;
            var userRaw = await _userManager.FindByEmailAsync(userEmail);
            string userID = userRaw.Id;
            var basket = await _basket.GetBasketByUserId(userID);
            var item = await _basketProduct.GetBasketProductByID(basket.ID, id);
            if (item != null)
            {
                item.Quantity++;
                await _basketProduct.UpdateQuantity(item);
            }
            else
            {
                await _basketProduct.AddBasketProduct(id, quantity, basket.ID);

            }

            return RedirectToAction("Index", "BasketProduct");
        }

        /// <summary>
        /// Calls the UpdateQuantity service to update an basket item matching the id with the given quantity
        /// </summary>
        /// <param name="id">Primary Key value</param>
        /// <param name="quantity">Quantity to update</param>
        /// <returns>Basket view</returns>
        [HttpPost]
        public async Task<IActionResult> Update(int id, int quantity)
        {
            string userEmail = User.Identity.Name;
            var userRaw = await _userManager.FindByEmailAsync(userEmail);
            string userID = userRaw.Id;
            var basket = await _basket.GetBasketByUserId(userID);

            BasketProduct basketProduct = await _basketProduct.GetBasketProductByID(basket.ID, id);
            basketProduct.Quantity = quantity;
            await _basketProduct.UpdateQuantity(basketProduct);
            return RedirectToAction("Index", "BasketProduct");
        }

        /// <summary>
        /// Calls the DeleteBasketProductByID service to delete a basket item matching the given ID
        /// </summary>
        /// <param name="id">Primary Key value</param>
        /// <returns>Basket view</returns>
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            string userEmail = User.Identity.Name;
            var userRaw = await _userManager.FindByEmailAsync(userEmail);
            string userID = userRaw.Id;
            var basket = await _basket.GetBasketByUserId(userID);

            await _basketProduct.DeleteBasketProductByID(basket.ID, id);
            return RedirectToAction("Index", "BasketProduct");
        }
    }
}
