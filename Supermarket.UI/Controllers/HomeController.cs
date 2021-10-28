using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Supermarket.Core.Domains;
using Supermarket.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var res = await "http://localhost:5000".AppendPathSegment("api/users/login")
               .SetQueryParams(new { username = username, password = password })
               .GetJsonAsync<User>();

            if (!string.IsNullOrEmpty(res.Id.ToString()))
            {
                HttpContext.Session.SetString("session", res.Id.ToString());
            }
            else
            {
                return View();
            }

            return RedirectToAction("Index", "Product");
        }
    }
}
