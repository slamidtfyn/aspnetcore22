using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetcore22.Models;
using dotnetcore22;

namespace dotnetcore22.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices]CoreClrHelpers clrHelpers)
        {
            ViewBag.Version=clrHelpers.GetCoreClrVersion();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
