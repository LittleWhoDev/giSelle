using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using giSelle.Models;

namespace giSelle.Controllers
{
    public class ProductsController : Controller
    {
        private DomainDbContext db = new DomainDbContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.AllCategories = db.Categories.ToList();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,SKU,HasQuantity,Quantity,PriceInMU,Currency,CategoryIds")] CreateProductViewModel productView)
        {
            if (ModelState.IsValid)
            {
                var productData = MapperContext.mapper.Map<CreateProductViewModel, Product>(productView);

                var associatedCategories = db.Categories.Where(c => productView.CategoryIds.Contains(c.Id)).ToList();
                associatedCategories.ForEach(categoryObject => productData.Categories.Add(categoryObject));

                db.Products.Add(productData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AllCategories = db.Categories.ToList();
            return View();
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var productView = MapperContext.mapper.Map<Product, EditProductViewModel>(product);
            productView.CategoryIds = new int[product.Categories.Count()];
            product.Categories.Select((c, index) => new { id = c.Id, index }).ToList()
                .ForEach(pair => productView.CategoryIds[pair.index] = pair.id);

            ViewBag.AllCategories = db.Categories.ToList();
            return View(productView);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,SKU,HasQuantity,Quantity,PriceInMU,Currency,CategoryIds")] EditProductViewModel productView)
        {
            if (ModelState.IsValid)
            {
                var productData = MapperContext.mapper.Map<EditProductViewModel, Product>(productView);
                db.Products.Attach(productData);
                db.Entry(productData).Collection(p => p.Categories).Load();

                if (productView.CategoryIds == null) productView.CategoryIds = new int[0];
                var newCategories = db.Categories.Where(c => productView.CategoryIds.Contains(c.Id)).ToList();
                var categoriesToAdd = newCategories.Except(productData.Categories).ToList();
                var categoriesToRemove = productData.Categories.Except(newCategories).ToList();

                categoriesToAdd.ForEach(category => productData.Categories.Add(category));
                categoriesToRemove.ForEach(category => productData.Categories.Remove(category));

                db.Entry(productData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AllCategories = db.Categories.ToList();
            return View(productView);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
