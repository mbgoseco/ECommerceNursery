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
                var expected = await inventoryService.GetProductByID(1);
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

    }
}
