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
    
    public partial class Donante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donante()
        {
            this.ObrasRecibidas = new HashSet<ObrasRecibidas>();
        }
    
        public string idDonante { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string procedencia { get; set; }
        public string telefono { get; set; }
        public string correoElectronico { get; set; }
        public string nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObrasRecibidas> ObrasRecibidas { get; set; }
    }
}
