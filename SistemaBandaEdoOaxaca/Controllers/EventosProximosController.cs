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
    public class EventosProximosController : Controller
    {

        private BandaDelEstadoEntities db = new BandaDelEstadoEntities();

        // GET: EventosProximos
        public ActionResult VistaDetalleEventosProximosPublico(string id)
        {
            List<EventosProximos> lista = db.EventosProximos.ToList();
            var model = new DetalleEventos();
            model.eventos = lista;
            if (id != null)
            {
                model.seleccionadoEvento = lista.Find(s => s.idEvento == id);
                model.seleccionEventoId = id;
            }

            return View(model);
        }

        [Authorize]
        public ActionResult VistaDetalleEventosProximos(string id)
        {
            List<EventosProximos> lista = db.EventosProximos.ToList();
            var model = new DetalleEventos();
            model.eventos = lista;
            if (id != null)
            {
                model.seleccionadoEvento = lista.Find(s => s.idEvento == id);
                model.seleccionEventoId = id;
            }

            return View(model);
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(db.EventosProximos.ToList());
        }

        // GET: EventosProximos/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventosProximos eventosProximos = db.EventosProximos.Find(id);
            if (eventosProximos == null)
            {
                return HttpNotFound();
            }
            return View(eventosProximos);
        }

        // GET: EventosProximos/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventosProximos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "idEvento,fecha,lugar,horaEmpiezo,horaSalida,Orden")] EventosProximos eventosProximos)
        {
            if (ModelState.IsValid)
            {
                db.EventosProximos.Add(eventosProximos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventosProximos);
        }

        // GET: EventosProximos/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventosProximos eventosProximos = db.EventosProximos.Find(id);
            if (eventosProximos == null)
            {
                return HttpNotFound();
            }
            return View(eventosProximos);
        }

        // POST: EventosProximos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEvento,fecha,lugar,horaEmpiezo,horaSalida,Orden")] EventosProximos eventosProximos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventosProximos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventosProximos);
        }

        // GET: EventosProximos/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventosProximos eventosProximos = db.EventosProximos.Find(id);
            if (eventosProximos == null)
            {
                return HttpNotFound();
            }
            return View(eventosProximos);
        }

        // POST: EventosProximos/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EventosProximos eventosProximos = db.EventosProximos.Find(id);
            db.EventosProximos.Remove(eventosProximos);
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
