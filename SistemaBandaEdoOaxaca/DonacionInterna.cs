//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaBandaEdoOaxaca
{
    using System;
    using System.Collections.Generic;
    
    public partial class DonacionInterna
    {
        public string idMusico { get; set; }
        public string folio { get; set; }
        public string isReciproco { get; set; }
        public string objeto { get; set; }
        public string idDonacionInterna { get; set; }
        public string idEstado { get; set; }
    
        public virtual ObraMusical ObraMusical { get; set; }
        public virtual Estados Estados { get; set; }
        public virtual Musico Musico { get; set; }
    }
}
