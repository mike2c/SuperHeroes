﻿using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {

            switch (statusCode)
            {
                case 404:
                    return View("404");
            }

            return View();
        }
    }
}
