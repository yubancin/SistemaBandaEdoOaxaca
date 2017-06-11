using SistemaBandaEdoOaxaca.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SistemaBandaEdoOaxaca
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://bandadeledooaxaca.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private BandaDelEstadoEntities db = new BandaDelEstadoEntities();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int SumaDeDosNumeros(int num, int num2)
        {
            return num + num2;
        }

        [WebMethod]
        public String Mensaje()
        {
            String msn = "Retornar Cadena";
            return msn;
        }

        [WebMethod]
        public List<EventosProximos> listaEventosProximos()
        {
            List<EventosProximos> lista = db.EventosProximos.ToList();
            return lista;
         }

        [WebMethod]
        public DataTable tablaDeEventos()
        {
            ProgramaDominicalsController c = new ProgramaDominicalsController();
            List<EventosProximos> lista = db.EventosProximos.ToList();
            return c.ToDataTable(lista);
        }

    }
}
