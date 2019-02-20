using Microsoft.AspNetCore.Mvc;
using NurseryApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventory _context;

        public InventoryController(IInventory context)
        {
            _context = context;
        }
    }
}
