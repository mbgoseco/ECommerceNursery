using Microsoft.EntityFrameworkCore;
using NurseryApp.Data;
using NurseryApp.Models;
using NurseryApp.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NurseryTests
{
    public class CRUDTests
    {
        //Basket Product CRUD test
        [Fact]
        public async void CanCreateBasket()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("test").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                Basket basket = new Basket();
                BasketService basketService = new BasketService(context);
                await basketService.CreateBasketAsync(basket);
                var expected = await context.Baskets.FirstOrDefaultAsync(b => b.ID == basket.ID);
                Assert.Equal(expected, basket);

            }
        }

        [Fact]
        public async void CanGetBasket()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("test").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                Basket basket = new Basket();
                basket.UserID = "userString";
                BasketService basketService = new BasketService(context);
                await basketService.CreateBasketAsync(basket);
                var expected = await basketService.GetBasketByUserId("userString");
                Assert.Equal(expected, basket);

            }
        }

        [Fact]
        public async void CanUpdateBasket()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("test").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                Basket basket = new Basket();
                basket.UserID = "userString";
                BasketService basketService = new BasketService(context);
                await basketService.CreateBasketAsync(basket);
                basket.UserID = "new string";
                await basketService.UpdateBasketAsync(basket);
                Assert.Equal("new string", basket.UserID);

            }
        }

        //Product
        [Fact]
        public async void CanCreateProduct()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("test").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                InventoryService inventoryService = new InventoryService(context);
                Product product = new Product();
                await inventoryService.CreateProduct(product);
                var expected = await context.Products.FirstOrDefaultAsync(p => p.ID == product.ID);
                Assert.Equal(expected, product);
            }
        }

        [Fact]
        public async void CanGetProduct()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("test").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                InventoryService inventoryService = new InventoryService(context);
                Product product = new Product();
                await inventoryService.CreateProduct(product);
                var expected = await inventoryService.GetProductByID(product.ID);
                Assert.Equal(expected, product);
            }
        }

        [Fact]
        public async void CanGetAllProduct()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("check2").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                InventoryService inventoryService = new InventoryService(context);
                Product product = new Product();
                await inventoryService.CreateProduct(product);
                var expected = await inventoryService.GetAllProducts();
                Assert.Equal(new List<Product> { product }, expected);
            }
        }

        [Fact]
        public async void CanUpdateProduct()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("check3").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                InventoryService inventoryService = new InventoryService(context);
                Product product = new Product();
                product.Name = "flower";
                await inventoryService.CreateProduct(product);
                product.Name = "sunflower";
                await inventoryService.Update(product);
                var expected = await inventoryService.GetProductByID(product.ID);
                Assert.Equal("sunflower", expected.Name);
            }

        }

        [Fact]
        public async void CanDeleteProduct()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("check3").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                InventoryService inventoryService = new InventoryService(context);
                Product product = new Product();
                await inventoryService.CreateProduct(product);
                await inventoryService.DeleteProductByID(product.ID);
                var expected = await inventoryService.GetProductByID(product.ID);
                Assert.Null(expected);
            }

        }

        [Fact]
        public async void CanCreateBasketProduct()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("test").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                InventoryService inventoryService = new InventoryService(context);
                BasketProductService basketProductService = new BasketProductService(context);
                BasketService basketService = new BasketService(context);
                Basket basket = new Basket();
                await basketService.CreateBasketAsync(basket);
                Product product = new Product();
                await inventoryService.CreateProduct(product);
                await basketProductService.AddBasketProduct(product.ID, 3, basket.ID);
                var expected = await context.BasketProducts.FirstOrDefaultAsync(p => p.BasketID == basket.ID && p.ProductID == product.ID);
                Assert.NotNull(expected);
            }
        }

        [Fact]
        public async void CanGetBasketProduct()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("GetBasektProduct").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                InventoryService inventoryService = new InventoryService(context);
                BasketProductService basketProductService = new BasketProductService(context);
                BasketService basketService = new BasketService(context);
                Basket basket = new Basket();
                await basketService.CreateBasketAsync(basket);
                Product product = new Product();
                await inventoryService.CreateProduct(product);
                await basketProductService.AddBasketProduct(product.ID, 3, basket.ID);
                var actual = await basketProductService.GetBasketProductByID(basket.ID, product.ID);
                var expected = await context.BasketProducts.FirstOrDefaultAsync(p => p.BasketID == basket.ID && p.ProductID == product.ID);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public async void CanUpdateBasketProduct()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("GetBasektProduct").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                InventoryService inventoryService = new InventoryService(context);
                BasketProductService basketProductService = new BasketProductService(context);
                BasketService basketService = new BasketService(context);
                Basket basket = new Basket();
                await basketService.CreateBasketAsync(basket);
                Product product = new Product();
                await inventoryService.CreateProduct(product);
                await basketProductService.AddBasketProduct(product.ID, 3, basket.ID);
                var basketProduct = await basketProductService.GetBasketProductByID(basket.ID, product.ID);
                basketProduct.Quantity = 5;
                await basketProductService.UpdateQuantity(basketProduct);
                var actual = await basketProductService.GetBasketProductByID(basket.ID, product.ID);
                Assert.Equal(5, actual.Quantity);
            }
        }

        [Fact]
        public async void CanDeleteBasketProduct()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("GetBasektProduct").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                InventoryService inventoryService = new InventoryService(context);
                BasketProductService basketProductService = new BasketProductService(context);
                BasketService basketService = new BasketService(context);
                Basket basket = new Basket();
                await basketService.CreateBasketAsync(basket);
                Product product = new Product();
                await inventoryService.CreateProduct(product);
                await basketProductService.AddBasketProduct(product.ID, 3, basket.ID);
                var basketProduct = await basketProductService.GetBasketProductByID(basket.ID, product.ID);
                await basketProductService.DeleteBasketProductByID(basket.ID, product.ID);
                var actual = await basketProductService.GetBasketProductByID(basket.ID, product.ID);
                Assert.Null(actual);
            }
        }

        [Fact]
        public async void CanCreateCheckout()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("test").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                Checkout checkout = new Checkout();
                CheckoutService checkoutService = new CheckoutService(context);
                await checkoutService.CreateCheckoutAsync(checkout);
                var expected = await context.Checkouts.FirstOrDefaultAsync(b => b.ID == checkout.ID);
                Assert.Equal(expected, checkout);

            }
        }

        [Fact]
        public async void CanGetCheckout()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("test").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                Checkout checkout = new Checkout();
                checkout.UserID = "userString";
                CheckoutService checkoutService = new CheckoutService(context);
                await checkoutService.CreateCheckoutAsync(checkout);
                var expected = await checkoutService.GetCheckoutByUserId(checkout.UserID, checkout.ID);
                Assert.Equal(expected, checkout);

            }
        }

        [Fact]
        public async void CanUpdateCheckout()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("test").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                Checkout checkout = new Checkout();
                checkout.UserID = "userString";
                CheckoutService checkoutService = new CheckoutService(context);
                await checkoutService.CreateCheckoutAsync(checkout);
                checkout.UserID = "new string";
                await checkoutService.UpdateCheckoutAsync(checkout);
                Assert.Equal("new string", checkout.UserID);

            }
        }

        //Checkout Product
        [Fact]
        public async void CanCreateCheckoutProduct()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("test").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                InventoryService inventoryService = new InventoryService(context);
                CheckoutProductService checkoutProductService = new CheckoutProductService(context);
                CheckoutService checkoutService = new CheckoutService(context);
                Checkout checkout = new Checkout();
                await checkoutService.CreateCheckoutAsync(checkout);
                Product product = new Product();
                await inventoryService.CreateProduct(product);
                await checkoutProductService.AddCheckoutProduct(product.ID, 3, checkout.ID);
                var expected = await context.CheckoutProducts.FirstOrDefaultAsync(p => p.CheckoutID == checkout.ID && p.ProductID == product.ID);
                Assert.NotNull(expected);
            }
        }

        [Fact]
        public async void CanGetCheckoutProduct()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("GetBasektProduct").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                InventoryService inventoryService = new InventoryService(context);
                CheckoutProductService checkoutProductService = new CheckoutProductService(context);
                CheckoutService checkoutService = new CheckoutService(context);
                Checkout checkout = new Checkout();
                await checkoutService.CreateCheckoutAsync(checkout);
                Product product = new Product();
                await inventoryService.CreateProduct(product);
                await checkoutProductService.AddCheckoutProduct(product.ID, 3, checkout.ID);
                var actual = await checkoutProductService.GetCheckoutProductByID(checkout.ID, product.ID);
                var expected = await context.CheckoutProducts.FirstOrDefaultAsync(p => p.CheckoutID == checkout.ID && p.ProductID == product.ID);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public async void CanUpdateCheckoutProduct()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("GetBasektProduct").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                InventoryService inventoryService = new InventoryService(context);
                CheckoutProductService checkoutProductService = new CheckoutProductService(context);
                CheckoutService checkoutService = new CheckoutService(context);
                Checkout checkout = new Checkout();
                await checkoutService.CreateCheckoutAsync(checkout);
                Product product = new Product();
                await inventoryService.CreateProduct(product);
                await checkoutProductService.AddCheckoutProduct(product.ID, 3, checkout.ID);
                var checkoutProduct = await checkoutProductService.GetCheckoutProductByID(checkout.ID, product.ID);
                checkoutProduct.Quantity = 5;
                await checkoutProductService.UpdateQuantity(checkoutProduct);
                var actual = await checkoutProductService.GetCheckoutProductByID(checkout.ID, product.ID);
                Assert.Equal(5, actual.Quantity);
            }
        }

        [Fact]
        public async void CanDeleteCheckoutProduct()
        {
            DbContextOptions<NurseryDbContext> options = new DbContextOptionsBuilder<NurseryDbContext>().UseInMemoryDatabase("GetBasektProduct").Options;
            using (NurseryDbContext context = new NurseryDbContext(options))
            {
                InventoryService inventoryService = new InventoryService(context);
                CheckoutProductService checkoutProductService = new CheckoutProductService(context);
                CheckoutService checkoutService = new CheckoutService(context);
                Checkout checkout = new Checkout();
                await checkoutService.CreateCheckoutAsync(checkout);
                Product product = new Product();
                await inventoryService.CreateProduct(product);
                await checkoutProductService.AddCheckoutProduct(product.ID, 3, checkout.ID);
                var checkoutProduct = await checkoutProductService.GetCheckoutProductByID(checkout.ID, product.ID);
                await checkoutProductService.DeleteCheckoutProductByID(checkout.ID, product.ID);
                var actual = await checkoutProductService.GetCheckoutProductByID(checkout.ID, product.ID);
                Assert.Null(actual);
            }
        }

    }
}
