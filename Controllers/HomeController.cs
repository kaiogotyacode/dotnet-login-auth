﻿using LoginAuth.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginAuth.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {           

            return View();
        }
     
    }
}