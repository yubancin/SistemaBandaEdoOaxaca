using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaBandaEdoOaxaca;

namespace SistemaBandaEdoOaxaca.Controllers
{
    public class InstrumentosController : Controller
    {
        private BandaDelEstadoEntities db = new BandaDelEstadoEntities();

        // GET: Instrumentos
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Instrumentos.ToList());
        }

        // GET: Instrumentos/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrumentos instrumentos = db.Instrumentos.Find(id);
            if (instrumentos == null)
            {
                return HttpNotFound();
            }
            return View(instrumentos);
        }

        // GET: Instrumentos/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instrumentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "idInstrumento,nombreInstrumento")] Instrumentos instrumentos)
        {
            if (ModelState.IsValid)
            {
                db.Instrumentos.Add(instrumentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instrumentos);
        }

        // GET: Instrumentos/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrumentos instrumentos = db.Instrumentos.Find(id);
            if (instrumentos == null)
            {
                return HttpNotFound();
            }
            return View(instrumentos);
        }

        // POST: Instrumentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "idInstrumento,nombreInstrumento")] Instrumentos instrumentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instrumentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instrumentos);
        }

        // GET: Instrumentos/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrumentos instrumentos = db.Instrumentos.Find(id);
            if (instrumentos == null)
            {
                return HttpNotFound();
            }
            return View(instrumentos);
        }

        // POST: Instrumentos/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Instrumentos instrumentos = db.Instrumentos.Find(id);
            db.Instrumentos.Remove(instrumentos);
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
