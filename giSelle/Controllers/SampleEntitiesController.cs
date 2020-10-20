using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using giSelle.Models;

namespace giSelle.Controllers
{
    public class SampleEntitiesController : Controller
    {
        private SampleModel db = new SampleModel();

        // GET: SampleEntities
        public ActionResult Index()
        {
            return View(db.SampleEntities.ToList());
        }

        // GET: SampleEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleEntity sampleEntity = db.SampleEntities.Find(id);
            if (sampleEntity == null)
            {
                return HttpNotFound();
            }
            return View(sampleEntity);
        }

        // GET: SampleEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SampleEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] SampleEntity sampleEntity)
        {
            if (ModelState.IsValid)
            {
                db.SampleEntities.Add(sampleEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sampleEntity);
        }

        // GET: SampleEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleEntity sampleEntity = db.SampleEntities.Find(id);
            if (sampleEntity == null)
            {
                return HttpNotFound();
            }
            return View(sampleEntity);
        }

        // POST: SampleEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] SampleEntity sampleEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sampleEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sampleEntity);
        }

        // GET: SampleEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleEntity sampleEntity = db.SampleEntities.Find(id);
            if (sampleEntity == null)
            {
                return HttpNotFound();
            }
            return View(sampleEntity);
        }

        // POST: SampleEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SampleEntity sampleEntity = db.SampleEntities.Find(id);
            db.SampleEntities.Remove(sampleEntity);
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
