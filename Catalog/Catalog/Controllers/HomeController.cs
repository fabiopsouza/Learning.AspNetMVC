using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Catalog.Infrastructure.Repositories;
using Catalog.Models;
using PagedList;

namespace Catalog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int pageNumber = 1)
        {
            using (var productRep = new ProductRepository())
            {
                ViewBag.OnePageOfProducts = productRep.Get().ToPagedList(pageNumber, 8);
            }

            var allProducts = new List<ProductViewModel>();
            foreach (var item in ViewBag.OnePageOfProducts)
            {
                allProducts.Add(new ProductViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Preco = item.Preco,
                    PhotoOutput = item.Photo == null ? string.Empty :
                        String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(item.Photo))
                });
            }

            var countProducts = allProducts.Count();

            ViewBag.FirstRowOfProductList = countProducts.Equals(0) ? null : allProducts.Take(4);
            if (countProducts > 4)
                ViewBag.SecondRowOfProductList = countProducts.Equals(0) ? null : allProducts.GetRange(4, countProducts - 4);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}