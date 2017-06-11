using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaBandaEdoOaxaca
{
   
        public class DetalleEventos
        {
            public EventosProximos seleccionadoEvento { get; set; }
            public string seleccionEventoId { get; set; }
            public List<EventosProximos> eventos { get; set; }
        }
    
}