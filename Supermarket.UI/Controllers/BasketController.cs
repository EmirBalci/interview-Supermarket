using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.UI.Controllers
{
    public class BasketController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var basket = await "http://localhost:5000/"
                 .AppendPathSegment("api/baskets/getallbasketbyuserid")
              .SetQueryParams(new { id = new Guid(HttpContext.Session.GetString("session")) })
               .GetJsonAsync<IEnumerable<Basket>>();

            return View(basket);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            Basket basket = new Basket
            {
                Id = id
            };

            await "http://localhost:5000/"
                 .AppendPathSegment("api/baskets/deleteproduct")
              .PostJsonAsync(basket)
              .ReceiveJson();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Pay()
        {
            var basket = await "http://localhost:5000/"
                 .AppendPathSegment("api/baskets/getallbasketbyuserid")
              .SetQueryParams(new { id = new Guid(HttpContext.Session.GetString("session")) })
               .GetJsonAsync<IEnumerable<Basket>>();

            return View(basket);
        }

        [HttpGet]
        public async Task<IActionResult> PayCreditCard()
        {
            var basket = await "http://localhost:5000/"
                 .AppendPathSegment("api/baskets/getallbasketbyuserid")
              .SetQueryParams(new { id = new Guid(HttpContext.Session.GetString("session")) })
               .GetJsonAsync<IEnumerable<Basket>>();

            PayViewModel model = new PayViewModel
            {
                Baskets = basket.ToList(),
                UserId = new Guid(HttpContext.Session.GetString("session"))
            };

            try
            {
                var response = await "http://localhost:5000/"
                                 .AppendPathSegment("api/saleses/paycreditcard")
                              .PostJsonAsync(model)
                              .ReceiveJson();
            }
            catch (FlurlHttpException ex)
            {
                TempData["Error"] = ex.GetResponseStringAsync().Result;
                return RedirectToAction("Pay");
            }

            return RedirectToAction("Index","Product");
        }

        [HttpGet]
        public async Task<IActionResult> PayCash()
        {
            var basket = await "http://localhost:5000/"
                 .AppendPathSegment("api/baskets/getallbasketbyuserid")
              .SetQueryParams(new { id = new Guid(HttpContext.Session.GetString("session")) })
               .GetJsonAsync<IEnumerable<Basket>>();

            PayViewModel model = new PayViewModel
            {
                Baskets = basket.ToList(),
                UserId = new Guid(HttpContext.Session.GetString("session"))
            };

            try
            {
                var response = await "http://localhost:5000/"
                                 .AppendPathSegment("api/saleses/paycash")
                              .PostJsonAsync(model)
                              .ReceiveJson();
            }
            catch (FlurlHttpException ex)
            {
                TempData["Error"] = ex.GetResponseStringAsync().Result;
                return RedirectToAction("Pay");
            }

            return RedirectToAction("Index", "Product");
        }
    }
}
