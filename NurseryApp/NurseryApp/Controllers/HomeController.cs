﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action for policy testing
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = "Landscaper")]
        public IActionResult Test()
        {
            return View();
        }
    }
}
