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

        /// <summary>
        /// Constructor method that brings in services to be used by the InventoryController
        /// </summary>
        /// <param name="context">Inventory interface</param>
        public InventoryController(IInventory context)
        {
            _context = context;
        }
    }
}
