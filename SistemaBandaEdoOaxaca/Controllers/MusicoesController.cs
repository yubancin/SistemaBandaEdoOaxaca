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
    public class MusicoesController : Controller
    {
        private BandaDelEstadoEntities db = new BandaDelEstadoEntities();
      //  BandaDelEstadoEntities context = null;
        // GET: Musicoes


        [Authorize]
        public ActionResult Index()
        {
            var musico = db.Musico.Include(m => m.Cuenta).Include(m => m.Direccion).Include(m => m.Instrumentos);
            return View(musico.ToList());
        }


        // GET: Musicoes/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musico musico = db.Musico.Find(id);
            if (musico == null)
            {
                return HttpNotFound();
            }
            return View(musico);
        }

        // GET: Musicoes/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.idCuenta = new SelectList(db.Cuenta, "idCuenta", "usuario");
            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "calle");
            ViewBag.idInstrumento = new SelectList(db.Instrumentos, "idInstrumento", "nombreInstrumento");
            return View();
        }

        // POST: Musicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMusico,idCuenta,idDireccion,nombre,apellidoPaterno,apellidoMaterno,telefono,numEmpleado,nivel,nss,gradoEstudios,idInstrumento,correo")] Musico musico)
        {
            if (ModelState.IsValid)
            {
                db.Musico.Add(musico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCuenta = new SelectList(db.Cuenta, "idCuenta", "usuario", musico.idCuenta);
            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "calle", musico.idDireccion);
            ViewBag.idInstrumento = new SelectList(db.Instrumentos, "idInstrumento", "nombreInstrumento", musico.idInstrumento);
            return View(musico);
        }

        // GET: Musicoes/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musico musico = db.Musico.Find(id);
            if (musico == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCuenta = new SelectList(db.Cuenta, "idCuenta", "usuario", musico.idCuenta);
            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "calle", musico.idDireccion);
            ViewBag.idInstrumento = new SelectList(db.Instrumentos, "idInstrumento", "nombreInstrumento", musico.idInstrumento);
            return View(musico);
        }

        // POST: Musicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMusico,idCuenta,idDireccion,nombre,apellidoPaterno,apellidoMaterno,telefono,numEmpleado,nivel,nss,gradoEstudios,idInstrumento,correo")] Musico musico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCuenta = new SelectList(db.Cuenta, "idCuenta", "usuario", musico.idCuenta);
            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "calle", musico.idDireccion);
            ViewBag.idInstrumento = new SelectList(db.Instrumentos, "idInstrumento", "nombreInstrumento", musico.idInstrumento);
            return View(musico);
        }

        // GET: Musicoes/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musico musico = db.Musico.Find(id);
            if (musico == null)
            {
                return HttpNotFound();
            }
            return View(musico);
        }

        // POST: Musicoes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Musico musico = db.Musico.Find(id);
            db.Musico.Remove(musico);
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
