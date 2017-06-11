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
    public class ObrasRecibidasController : Controller
    {
        private BandaDelEstadoEntities db = new BandaDelEstadoEntities();

        // GET: ObrasRecibidas
        [Authorize]
        public ActionResult Index()
        {
            var obrasRecibidas = db.ObrasRecibidas.Include(o => o.Donante).Include(o => o.ObraMusical);
            return View(obrasRecibidas.ToList());
        }



        // GET: ObrasRecibidas/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObrasRecibidas obrasRecibidas = db.ObrasRecibidas.Find(id);
            if (obrasRecibidas == null)
            {
                return HttpNotFound();
            }
            return View(obrasRecibidas);
        }

        // GET: ObrasRecibidas/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.idDonante = new SelectList(db.Donante, "idDonante", "nombre");
            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra");
            return View();
        }

        // POST: ObrasRecibidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "folio,idDonante,idObraRecibida")] ObrasRecibidas obrasRecibidas)
        {
            if (ModelState.IsValid)
            {
                db.ObrasRecibidas.Add(obrasRecibidas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDonante = new SelectList(db.Donante, "idDonante", "apellidoPaterno", obrasRecibidas.idDonante);
            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra", obrasRecibidas.folio);
            return View(obrasRecibidas);
        }

        // GET: ObrasRecibidas/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObrasRecibidas obrasRecibidas = db.ObrasRecibidas.Find(id);
            if (obrasRecibidas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDonante = new SelectList(db.Donante, "idDonante", "apellidoPaterno", obrasRecibidas.idDonante);
            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra", obrasRecibidas.folio);
            return View(obrasRecibidas);
        }

        // POST: ObrasRecibidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "folio,idDonante,idObraRecibida")] ObrasRecibidas obrasRecibidas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obrasRecibidas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDonante = new SelectList(db.Donante, "idDonante", "apellidoPaterno", obrasRecibidas.idDonante);
            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra", obrasRecibidas.folio);
            return View(obrasRecibidas);
        }

        // GET: ObrasRecibidas/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObrasRecibidas obrasRecibidas = db.ObrasRecibidas.Find(id);
            if (obrasRecibidas == null)
            {
                return HttpNotFound();
            }
            return View(obrasRecibidas);
        }

        // POST: ObrasRecibidas/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ObrasRecibidas obrasRecibidas = db.ObrasRecibidas.Find(id);
            db.ObrasRecibidas.Remove(obrasRecibidas);
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
