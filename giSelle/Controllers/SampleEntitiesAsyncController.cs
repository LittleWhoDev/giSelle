using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using giSelle.Models;

namespace giSelle.Controllers
{
    public class SampleEntitiesAsyncController : Controller
    {
        private SampleModel db = new SampleModel();

        // GET: SampleEntitiesAsync
        public async Task<ActionResult> Index()
        {
            return View(await db.SampleEntities.ToListAsync());
        }

        // GET: SampleEntitiesAsync/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleEntity sampleEntity = await db.SampleEntities.FindAsync(id);
            if (sampleEntity == null)
            {
                return HttpNotFound();
            }
            return View(sampleEntity);
        }

        // GET: SampleEntitiesAsync/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SampleEntitiesAsync/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] SampleEntity sampleEntity)
        {
            if (ModelState.IsValid)
            {
                db.SampleEntities.Add(sampleEntity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sampleEntity);
        }

        // GET: SampleEntitiesAsync/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleEntity sampleEntity = await db.SampleEntities.FindAsync(id);
            if (sampleEntity == null)
            {
                return HttpNotFound();
            }
            return View(sampleEntity);
        }

        // POST: SampleEntitiesAsync/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] SampleEntity sampleEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sampleEntity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sampleEntity);
        }

        // GET: SampleEntitiesAsync/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleEntity sampleEntity = await db.SampleEntities.FindAsync(id);
            if (sampleEntity == null)
            {
                return HttpNotFound();
            }
            return View(sampleEntity);
        }

        // POST: SampleEntitiesAsync/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SampleEntity sampleEntity = await db.SampleEntities.FindAsync(id);
            db.SampleEntities.Remove(sampleEntity);
            await db.SaveChangesAsync();
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
