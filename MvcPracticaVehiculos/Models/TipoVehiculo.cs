//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcPracticaVehiculos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoVehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoVehiculo()
        {
            this.Vehiculo = new HashSet<Vehiculo>();
        }

        public int idTipo { get; set; }
        [Required(ErrorMessage = "El nombre del tipo es obligatorio")]
        [DisplayName("Nombre: ")]
        public string nombreTipo { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [DisplayName("Descripcion: ")]
        public string descripcionTipo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
