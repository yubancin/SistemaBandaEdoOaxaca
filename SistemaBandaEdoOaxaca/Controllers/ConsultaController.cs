using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBandaEdoOaxaca.Controllers
{

    [Authorize]
    public class ConsultaController : Controller
    {
        // GET: Consulta
        public ActionResult Index()
        {
            BandaDelEstadoEntities GE = new BandaDelEstadoEntities();
            return View(GE.ObraMusical.ToList());
          
        }

        [HttpPost]
        public ActionResult Search(string Location)
        {
            BandaDelEstadoEntities GE = new BandaDelEstadoEntities();
            var result = GE.ObraMusical.Where(x => x.tituloObra.Contains(Location)).Select(x => new { x.tituloObra, x.autor,x.disponibilidad,x.folio,x.estado,x.fechaIngreso,x.region,x.paginas,x.anio,x.numPartichelas});
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}