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

namespace MvcEjemplo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.ProductoAlmacen = new HashSet<ProductoAlmacen>();
            this.Etiquetas = new HashSet<Etiquetas>();
        }
    
        public int idProducto { get; set; }
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [DisplayName("Nombre del producto")]
        public string nombre { get; set; }
        [DisplayName("Fabricante del producto")]
        [DataType(DataType.MultilineText)]
        public string fabricante { get; set; }
        [DisplayName("Precio de compra")]
        [DataType(DataType.Currency)]
        public double precioCompra { get; set; }
        [DisplayName("Precio de venta")]
        [DataType(DataType.Currency)]
        public double precioVenta { get; set; }
        [DisplayName("Tipo de categoria")]
        [Range(1,4,ErrorMessage = "El valor tiene que ser entre 1 y 4")]
        public int idCategoria { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductoAlmacen> ProductoAlmacen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Etiquetas> Etiquetas { get; set; }
    }
}
