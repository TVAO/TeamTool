using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TeamTool.Controllers.Web
{
    public class MemberController : Controller
    {

        public IActionResult Members()
        {
            return View();
        }

    }
}
