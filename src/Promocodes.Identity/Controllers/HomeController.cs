﻿using Microsoft.AspNetCore.Mvc;

namespace Promocodes.Identity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
