//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppVentas.MODEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_detalleVenta
    {
        public int iDDetalleVenta { get; set; }
        public Nullable<int> iDVenta { get; set; }
        public Nullable<int> iDProducto { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<decimal> precio { get; set; }
        public Nullable<decimal> total { get; set; }
    
        public virtual tb_producto tb_producto { get; set; }
        public virtual tb_venta tb_venta { get; set; }
    }
}
