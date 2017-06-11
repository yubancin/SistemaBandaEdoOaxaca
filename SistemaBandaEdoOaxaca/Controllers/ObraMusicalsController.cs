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
    public class ObraMusicalsController : Controller
    {
        private BandaDelEstadoEntities db = new BandaDelEstadoEntities();

        // GET: ObraMusicals
        [Authorize]
        public ActionResult Index()
        {
            var obraMusical = db.ObraMusical.Include(o => o.Genero);
            return View(obraMusical.ToList());
        }

        // GET: ObraMusicals/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObraMusical obraMusical = db.ObraMusical.Find(id);
            if (obraMusical == null)
            {
                return HttpNotFound();
            }
            return View(obraMusical);
        }

        // GET: ObraMusicals/Create
        [Authorize]
        public ActionResult Create()

        {
            ViewBag.idGenero = new SelectList(db.Genero, "idGenero", "genero1");
            return View();
        }
        // POST: ObraMusicals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "folio,tituloObra,autor,anio,region,disponibilidad,paginas,numPartichelas,estado,fechaIngreso,idGenero")] ObraMusical obraMusical)
        {
            if (ModelState.IsValid)
            {
                db.ObraMusical.Add(obraMusical);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idGenero = new SelectList(db.Genero, "idGenero", "genero1", obraMusical.idGenero);
            return View(obraMusical);
        }

        // GET: ObraMusicals/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObraMusical obraMusical = db.ObraMusical.Find(id);
            if (obraMusical == null)
            {
                return HttpNotFound();
            }
            ViewBag.idGenero = new SelectList(db.Genero, "idGenero", "genero1", obraMusical.idGenero);
            return View(obraMusical);
        }

        // POST: ObraMusicals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "folio,tituloObra,autor,anio,region,disponibilidad,paginas,numPartichelas,estado,fechaIngreso,idGenero")] ObraMusical obraMusical)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obraMusical).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idGenero = new SelectList(db.Genero, "idGenero", "genero1", obraMusical.idGenero);
            return View(obraMusical);
        }

        // GET: ObraMusicals/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObraMusical obraMusical = db.ObraMusical.Find(id);
            if (obraMusical == null)
            {
                return HttpNotFound();
            }
            return View(obraMusical);
        }

        // POST: ObraMusicals/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ObraMusical obraMusical = db.ObraMusical.Find(id);
            db.ObraMusical.Remove(obraMusical);
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
