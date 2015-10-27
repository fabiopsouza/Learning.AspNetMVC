using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Catalog.Infrastructure.Repositories;
using Catalog.Models;
using PagedList;

namespace Catalog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string sort = "Name", bool sortReverse = false, int pageNumber = 1, string searchFor = "")
        {
            ViewBag.CurrentSort = sortReverse;

            using (var productRep = new ProductRepository())
            {
                ViewBag.OnePageOfProducts = ((List<Product>)productRep.Get(sort, ViewBag.CurrentSort, searchFor)).ToPagedList(pageNumber, 10);
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

            ViewBag.AllProducts = allProducts;

            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            using (var productRep = new ProductRepository())
            {
                return View(productRep.GetById(id));
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name, Description, Preco")]
            Product product, HttpPostedFileBase upload)
        {
            try
            {
                using (var reader = new BinaryReader(upload.InputStream))
                {
                    product.Photo = reader.ReadBytes(upload.ContentLength);
                }

                using (var productRep = new ProductRepository())
                {
                   productRep.Create(product);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            using (var productRep = new ProductRepository())
            {
                return View(productRep.GetById(id));
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Name, Description, Preco")]
            Product product, HttpPostedFileBase upload)
        {
            try
            {
                using (var reader = new BinaryReader(upload.InputStream))
                {
                    product.Photo = reader.ReadBytes(upload.ContentLength);
                }

                using (var productRep = new ProductRepository())
                {
                    productRep.Edit(product);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (var productRep = new ProductRepository())
            {
                return View(productRep.GetById(id));
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            try
            {
                using (var productRep = new ProductRepository())
                {
                    productRep.Delete(product);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
