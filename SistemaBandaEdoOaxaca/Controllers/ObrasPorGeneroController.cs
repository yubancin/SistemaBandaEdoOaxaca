using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBandaEdoOaxaca.Controllers
{
    [Authorize]
    public class ObrasPorGeneroController : Controller
    {
        BandaDelEstadoEntities context = null;
        public ActionResult Index()
        {
            context = new BandaDelEstadoEntities();
            return View(context.Genero.Take(100).ToList());
        }

        [Authorize]
        public ActionResult Detalle(string id)
        {
            context = new BandaDelEstadoEntities();

            if (id != null)
            {
                return PartialView(context.ObraMusical.Where(x => x.idGenero == id).ToList());
            }
            return PartialView(context);
        }
    }
}