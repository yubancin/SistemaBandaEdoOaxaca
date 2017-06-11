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
    public class DonantesController : Controller
    {


        private BandaDelEstadoEntities db = new BandaDelEstadoEntities();
        BandaDelEstadoEntities context = null;

        public ActionResult PublicoIndex()
        {
            return View(db.Donante.ToList());
        }
        
          


        // GET: Donantes
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Donante.ToList());
        }



        public ActionResult Detalle(string id)
        {
            context = new BandaDelEstadoEntities();
          
            if (id != null)
            {
                return PartialView(context.ObrasRecibidas.Where(x => x.idDonante == id).ToList());
            }
            return PartialView(context);
        }

        // GET: Donantes/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donante donante = db.Donante.Find(id);
            if (donante == null)
            {
                return HttpNotFound();
            }
            return View(donante);
        }

        // GET: Donantes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "idDonante,apellidoPaterno,apellidoMaterno,procedencia,telefono,correoElectronico,nombre")] Donante donante)
        {
            if (ModelState.IsValid)
            {
                db.Donante.Add(donante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donante);
        }

        // GET: Donantes/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donante donante = db.Donante.Find(id);
            if (donante == null)
            {
                return HttpNotFound();
            }
            return View(donante);
        }

        // POST: Donantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDonante,apellidoPaterno,apellidoMaterno,procedencia,telefono,correoElectronico,nombre")] Donante donante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donante);
        }

        // GET: Donantes/Delete/5
        [Authorize]
        public ActionResult Delete(string id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donante donante = db.Donante.Find(id);
            if (donante == null)
            {
                return HttpNotFound();
            }
            return View(donante);
        }

        // POST: Donantes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Donante donante = db.Donante.Find(id);
            db.Donante.Remove(donante);
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
