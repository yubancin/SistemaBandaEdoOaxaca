using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaBandaEdoOaxaca;
using System.Reflection;

namespace SistemaBandaEdoOaxaca.Controllers
{
    public class ProgramaDominicalsController : Controller
    {
        private BandaDelEstadoEntities db = new BandaDelEstadoEntities();


        public ActionResult PublicoIndex()
        {
            var programaDominical = db.ProgramaDominical.Include(p => p.ObraMusical);
            return View(programaDominical.ToList());
        }


        // GET: ProgramaDominicals
        public ActionResult Index()
        {
            var programaDominical = db.ProgramaDominical.Include(p => p.ObraMusical);
            return View(programaDominical.ToList());
        }

        // GET: ProgramaDominicals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramaDominical programaDominical = db.ProgramaDominical.Find(id);
            if (programaDominical == null)
            {
                return HttpNotFound();
            }
            return View(programaDominical);
        }

        // GET: ProgramaDominicals/Create
        public ActionResult Create()
        {
            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra");
            return View();
        }

        // POST: ProgramaDominicals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProgramaDominical,folio,fecha,lugar")] ProgramaDominical programaDominical)
        {
            if (ModelState.IsValid)
            {
                db.ProgramaDominical.Add(programaDominical);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra", programaDominical.folio);
            return View(programaDominical);
        }

        // GET: ProgramaDominicals/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramaDominical programaDominical = db.ProgramaDominical.Find(id);
            if (programaDominical == null)
            {
                return HttpNotFound();
            }
            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra", programaDominical.folio);
            return View(programaDominical);
        }

        // POST: ProgramaDominicals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProgramaDominical,folio,fecha,lugar")] ProgramaDominical programaDominical)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programaDominical).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.folio = new SelectList(db.ObraMusical, "folio", "tituloObra", programaDominical.folio);
            return View(programaDominical);
        }

        // GET: ProgramaDominicals/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramaDominical programaDominical = db.ProgramaDominical.Find(id);
            if (programaDominical == null)
            {
                return HttpNotFound();
            }
            return View(programaDominical);
        }

        // POST: ProgramaDominicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProgramaDominical programaDominical = db.ProgramaDominical.Find(id);
            db.ProgramaDominical.Remove(programaDominical);
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


        public List<ProgramaDominical> getProgramas()
        {
            var programaDominical = db.ProgramaDominical.ToList();
            return programaDominical;
        }


        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }



    }
}
