using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TeamTool.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Team Tool";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "General Inquiries";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

    }

}
