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
    }
}
