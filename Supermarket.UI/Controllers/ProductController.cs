using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.Domains;
using Supermarket.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.UI.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var session = HttpContext.Session.GetString("session");

            if (string.IsNullOrEmpty(session))
            {
                return RedirectToAction("Login", "Home");
            }

            var res = await "http://localhost:5000".AppendPathSegment("api/products/getallproducts")
               .GetJsonAsync<IEnumerable<Product>>();

            return View(res);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var res = await "http://localhost:5000/"
                 .AppendPathSegment("api/products/addproduct")
              .PostJsonAsync(product)
              .ReceiveJson<Product>();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            Product product = new Product
            {
                Id = id
            };

            await "http://localhost:5000/"
                 .AppendPathSegment("api/products/removeproduct")
              .PostJsonAsync(product)
              .ReceiveJson();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeletePopUp(Guid id)
        {
            var product = await "http://localhost:5000/"
                 .AppendPathSegment("api/products/getproductbyid")
              .SetQueryParams(new { id = id })
               .GetJsonAsync<Product>();

            return PartialView("_DeletePopUp", product);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(Guid id)
        {
            var product = await "http://localhost:5000/"
                 .AppendPathSegment("api/products/getproductbyid")
              .SetQueryParams(new { id = id })
               .GetJsonAsync<Product>();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            await "http://localhost:5000/"
                 .AppendPathSegment("api/products/editproduct")
              .PostJsonAsync(product)
              .ReceiveJson();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddedBasket(Guid id)
        {
            var product = await "http://localhost:5000/"
                 .AppendPathSegment("api/products/getproductbyid")
              .SetQueryParams(new { id = id })
               .GetJsonAsync<Product>();

            Basket basket = new Basket
            {
                Id = Guid.NewGuid(),
                Piece = 1,
                ProductId = id,
                UserId = new Guid(HttpContext.Session.GetString("session"))
            };

            await "http://localhost:5000/"
                 .AppendPathSegment("api/baskets/addbasket")
              .PostJsonAsync(basket)
              .ReceiveJson();

            return PartialView("_AddedBasketPopUp");
        }
    }
}
