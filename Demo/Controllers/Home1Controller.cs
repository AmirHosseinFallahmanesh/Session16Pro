using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class Home1Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.id = HttpContext.Session.Id;
            return View();
        }
    }
}