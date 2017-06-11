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
    public class DonacionExternasController : Controller
    {
        private BandaDelEstadoEntities db = new BandaDelEstadoEntities();


        public ActionResult Aviso()
        {
            return View();
        }

        // GET: DonacionExternas
        [Authorize]
        public ActionResult Index()
        {
            var donacionExterna = db.DonacionExterna.Include(d => d.ObraMusical).Include(d => d.Estados).Include(d => d.Solicitante);
            return View(donacionExterna.ToList());
        }

        // GET: DonacionExternas/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonacionExterna donacionExterna = db.DonacionExterna.Find(id);
            if (donacionExterna == null)
            {
                return HttpNotFound();
            }
            return View(donacionExterna);
        }

        // GET: DonacionExternas/Create
     
        public ActionResult Create()
        {
            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra");
            ViewBag.idEstado = new SelectList(db.Estados, "idEstado", "estado");
            ViewBag.idSolicitante = new SelectList(db.Solicitante, "idSolicitante", "nombre");
            return View();
        }

        // POST: DonacionExternas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public ActionResult Create([Bind(Include = "idSolicitante,folio,isReciproco,objeto,idDonacionExterna,idEstado")] DonacionExterna donacionExterna)
        {
            if (ModelState.IsValid)
            {
                db.DonacionExterna.Add(donacionExterna);
                db.SaveChanges();
                return RedirectToAction("Aviso");
            }

            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra", donacionExterna.folio);
            ViewBag.idEstado = new SelectList(db.Estados, "idEstado", "estado", donacionExterna.idEstado);
            ViewBag.idSolicitante = new SelectList(db.Solicitante, "idSolicitante", "nombre", donacionExterna.idSolicitante);
            return View(donacionExterna);
        }

        // GET: DonacionExternas/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonacionExterna donacionExterna = db.DonacionExterna.Find(id);
            if (donacionExterna == null)
            {
                return HttpNotFound();
            }
            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra", donacionExterna.folio);
            ViewBag.idEstado = new SelectList(db.Estados, "idEstado", "estado", donacionExterna.idEstado);
            ViewBag.idSolicitante = new SelectList(db.Solicitante, "idSolicitante", "nombre", donacionExterna.idSolicitante);
            return View(donacionExterna);
        }

        // POST: DonacionExternas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "idSolicitante,folio,isReciproco,objeto,idDonacionExterna,idEstado")] DonacionExterna donacionExterna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donacionExterna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra", donacionExterna.folio);
            ViewBag.idEstado = new SelectList(db.Estados, "idEstado", "estado", donacionExterna.idEstado);
            ViewBag.idSolicitante = new SelectList(db.Solicitante, "idSolicitante", "nombre", donacionExterna.idSolicitante);
            return View(donacionExterna);
        }

        // GET: DonacionExternas/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonacionExterna donacionExterna = db.DonacionExterna.Find(id);
            if (donacionExterna == null)
            {
                return HttpNotFound();
            }
            return View(donacionExterna);
        }

        // POST: DonacionExternas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(string id)
        {
            DonacionExterna donacionExterna = db.DonacionExterna.Find(id);
            db.DonacionExterna.Remove(donacionExterna);
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
