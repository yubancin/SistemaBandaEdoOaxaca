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
    public class DonacionInternasController : Controller
    {
        private BandaDelEstadoEntities db = new BandaDelEstadoEntities();

        // GET: DonacionInternas
        [Authorize]
        public ActionResult Index()
        {
            var donacionInterna = db.DonacionInterna.Include(d => d.ObraMusical).Include(d => d.Estados).Include(d => d.Musico);
            return View(donacionInterna.ToList());
        }

        // GET: DonacionInternas/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonacionInterna donacionInterna = db.DonacionInterna.Find(id);
            if (donacionInterna == null)
            {
                return HttpNotFound();
            }
            return View(donacionInterna);
        }

        // GET: DonacionInternas/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra");
            ViewBag.idEstado = new SelectList(db.Estados, "idEstado", "estado");
            ViewBag.idMusico = new SelectList(db.Musico, "idMusico", "idCuenta");
            return View();
        }

        // POST: DonacionInternas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMusico,folio,isReciproco,objeto,idDonacionInterna,idEstado")] DonacionInterna donacionInterna)
        {
            if (ModelState.IsValid)
            {
                db.DonacionInterna.Add(donacionInterna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra", donacionInterna.folio);
            ViewBag.idEstado = new SelectList(db.Estados, "idEstado", "estado", donacionInterna.idEstado);
            ViewBag.idMusico = new SelectList(db.Musico, "idMusico", "idCuenta", donacionInterna.idMusico);
            return View(donacionInterna);
        }

        // GET: DonacionInternas/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonacionInterna donacionInterna = db.DonacionInterna.Find(id);
            if (donacionInterna == null)
            {
                return HttpNotFound();
            }
            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra", donacionInterna.folio);
            ViewBag.idEstado = new SelectList(db.Estados, "idEstado", "estado", donacionInterna.idEstado);
            ViewBag.idMusico = new SelectList(db.Musico, "idMusico", "idCuenta", donacionInterna.idMusico);
            return View(donacionInterna);
        }

        // POST: DonacionInternas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "idMusico,folio,isReciproco,objeto,idDonacionInterna,idEstado")] DonacionInterna donacionInterna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donacionInterna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra", donacionInterna.folio);
            ViewBag.idEstado = new SelectList(db.Estados, "idEstado", "estado", donacionInterna.idEstado);
            ViewBag.idMusico = new SelectList(db.Musico, "idMusico", "idCuenta", donacionInterna.idMusico);
            return View(donacionInterna);
        }

        // GET: DonacionInternas/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonacionInterna donacionInterna = db.DonacionInterna.Find(id);
            if (donacionInterna == null)
            {
                return HttpNotFound();
            }
            return View(donacionInterna);
        }

        // POST: DonacionInternas/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonacionInterna donacionInterna = db.DonacionInterna.Find(id);
            db.DonacionInterna.Remove(donacionInterna);
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
