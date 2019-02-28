using Microsoft.Extensions.Configuration;
using NurseryApp.Data;
using NurseryApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Services
{
    public class BasketController : IBasket
    {
        private readonly NurseryDbContext _context;

        public BasketController(NurseryDbContext context)
        {
            _context = context;
        }
        public Task CreateBasket(Basket basket)
        {
            _context.
        }

        public Task UpdateBasket(Basket basket)
        {
            throw new NotImplementedException();
        }
    }
}
