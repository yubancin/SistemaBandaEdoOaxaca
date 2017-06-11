using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBandaEdoOaxaca.Controllers
{
    public class ApiController : Controller
    {
        public ActionResult Index()
        {
            BandaDelEstadoEntities GE = new BandaDelEstadoEntities();
            return View(GE.catalogocoord.ToList());
        }

        public ActionResult IndexApi()
        {
            BandaDelEstadoEntities GE = new BandaDelEstadoEntities();
            return View(GE.catalogocoord.ToList());
        }


        [HttpPost]
        public ActionResult Search(string Location)
        {
            BandaDelEstadoEntities GE = new BandaDelEstadoEntities();
            var result = GE.catalogocoord.Where(x => x.clavecct.StartsWith(Location)).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SearchAll(string Location)
        {
            BandaDelEstadoEntities GE = new BandaDelEstadoEntities();
            var result = GE.catalogocoord.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}