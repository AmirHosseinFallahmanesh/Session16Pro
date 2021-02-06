using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Microsoft.AspNetCore.Http;
using Demo.Infrastuture;
using Newtonsoft.Json;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           
          
            //  HttpContext.WriteCookie("cart01", new Cart());
           Cart cart= HttpContext.ReadCookie<Cart>("cart01");

            return View(cart);
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
