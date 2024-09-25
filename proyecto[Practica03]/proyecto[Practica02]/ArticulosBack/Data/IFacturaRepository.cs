using ArticulosBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosBack.Data
{
    internal interface IFacturaRepository
    {
        bool Save(Factura oFactura);
        List<Factura> GetAll();
        Factura? GetByID(int id);
    }
}
