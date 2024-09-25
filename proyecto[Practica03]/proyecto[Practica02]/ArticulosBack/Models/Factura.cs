using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosBack.Models
{
    public class Factura
    {
        public int Codigo { get; set; }
        public int MetodoPago { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }

        public List<DetalleFactura> Detalles;
        public List<DetalleFactura> GetDetalles()
        {
            return Detalles;
        }
        public Factura(int metodopago, string cliente, DateTime fecha)
        {
            Detalles = new List<DetalleFactura>();
            MetodoPago = metodopago;
            Cliente = cliente;
            Fecha = fecha;
        }
        public Factura()
        {
            Detalles = new List<DetalleFactura>();
        }
        public void AddDetalle(DetalleFactura detalle)
        {
            if (detalle != null)
            {
                Detalles.Add(detalle);
            }
        }
        public void RemoverDetalle(int id)
        {
            Detalles.RemoveAt(id);
        }
        public float Total()
        {
            float total = 0;
            foreach (var detalle in Detalles)
            {
                total += detalle.SubTotal();
            }
            return total;
        }
    }
}
