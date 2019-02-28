using Microsoft.AspNetCore.Identity;
using NurseryApp.Models;
using NurseryApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Controllers
{
    public class CheckoutController
    {
        private readonly ICheckout _context;
        private readonly IBasket _basketcontext;
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckoutController(UserManager<ApplicationUser> userManager, ICheckout context)
        {
            _context = context;
            _userManager = userManager;
        }
    }
}
