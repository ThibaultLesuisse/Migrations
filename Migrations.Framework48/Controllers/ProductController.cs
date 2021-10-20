using Migrations.Framework48.Repositories;
using Migrations.Framework48.ViewModels;
using System;
using System.Web.Mvc;
using System.Runtime.Caching;
using System.Web;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace Migrations.Framework48.Controllers
{
    public class ProductController: Controller
    {
        private readonly IProductRepository _productRepository = new ProductRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var products = _productRepository.Get();

            //Session
            Session["Products"] = products;

            //Cache
            MemoryCache.Default.Set("Products", products, new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10) });
            HttpContext.Cache.Insert("Products", products);

            //TempData
            TempData.Save(ControllerContext, TempDataProvider);

            //ViewData
            ViewData["Products"] = products;

            //ViewBag
            ViewBag.Products = products;

            //Current Culture
            var lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            //HttpContext
            var context = System.Web.HttpContext.Current;

            //Cookies
            Response.Cookies.Add(new HttpCookie("ProductCookie", products.Count().ToString()));

            //Headers
            Response.Headers.Add("X-Products", products.Count().ToString());

            //UrlHelper
            var index = Url.Action("Index");

            return View(new OverviewViewModel { Products = products});
        }

        [ChildActionOnly]
        [ActionName("Categories")]
        public ActionResult Categories()
        {
            var selectList = new SelectList(new[] { "Robots", "Drones", "Kitchen Appliances" });
            return PartialView("Partials/_Categories", selectList);
        }

        [HttpGet]
        [OutputCache(Duration = 30, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Add() => View(new ProductViewModel());

        [HttpPost]
        public ActionResult Add(ProductViewModel vm) {

            if (!ModelState.IsValid)
                return View(vm);

            var randomizer = new Random();
            _productRepository.Add(new Domain.Product { Description = vm.Description, Id = randomizer.Next(0, int.MaxValue), Name = vm.Name, Price = vm.Price });

            return RedirectToAction("Index");
        }
    }
}