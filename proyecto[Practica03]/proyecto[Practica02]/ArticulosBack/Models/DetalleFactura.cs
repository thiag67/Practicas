using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosBack.Models
{
    public class DetalleFactura
    {

        public int Codigo { get; set; }
        public Articulo Producto { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }

        public float SubTotal()
        {
            return Cantidad * Precio;
        }
        public DetalleFactura(Articulo producto, int cantidad, float precio)
        {
            Producto = producto;
            Cantidad = cantidad;
            Precio = precio;
        }
        public DetalleFactura()
        {
        }


    }
}
