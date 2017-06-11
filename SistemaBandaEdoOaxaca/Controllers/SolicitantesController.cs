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
    public class SolicitantesController : Controller
    {
        private BandaDelEstadoEntities db = new BandaDelEstadoEntities();

        // GET: Solicitantes
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Solicitante.ToList());
        }

        // GET: Solicitantes/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitante solicitante = db.Solicitante.Find(id);
            if (solicitante == null)
            {
                return HttpNotFound();
            }
            return View(solicitante);
        }

        // GET: Solicitantes/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Solicitantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSolicitante,nombre,apellidoPaterno,apellidoMaterno,dependencia,telefono,correoElectronico")] Solicitante solicitante)
        {
            if (ModelState.IsValid)
            {
                db.Solicitante.Add(solicitante);
                db.SaveChanges();
                return RedirectToAction("../DonacionExternas/Create");
            }

            return View(solicitante);
        }

        // GET: Solicitantes/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitante solicitante = db.Solicitante.Find(id);
            if (solicitante == null)
            {
                return HttpNotFound();
            }
            return View(solicitante);
        }

        // POST: Solicitantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSolicitante,nombre,apellidoPaterno,apellidoMaterno,dependencia,telefono,correoElectronico")] Solicitante solicitante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(solicitante);
        }

        // GET: Solicitantes/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitante solicitante = db.Solicitante.Find(id);
            if (solicitante == null)
            {
                return HttpNotFound();
            }
            return View(solicitante);
        }

        // POST: Solicitantes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Solicitante solicitante = db.Solicitante.Find(id);
            db.Solicitante.Remove(solicitante);
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
