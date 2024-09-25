using ArticulosBack.Data;
using ArticulosBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosBack.Services
{
    public class FacturasManager
    {
        IFacturaRepository oFacturaRepositorio = new FacturaRepository();
        public FacturasManager()
        {
            oFacturaRepositorio = new FacturaRepository();
        }
        public bool Save(Factura oFactura)
        {
            return oFacturaRepositorio.Save(oFactura);
        }
        public List<Factura> GetAll()
        {
            return oFacturaRepositorio.GetAll();
        }
        public Factura? GetByID(int id)
        {
            return oFacturaRepositorio.GetByID(id);
        }

    }
}

