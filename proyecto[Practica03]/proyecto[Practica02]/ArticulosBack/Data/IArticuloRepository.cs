using ArticulosBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosBack.Data
{
    internal interface IArticuloRepository
    {
        bool Agregar(Articulo oArticulo);
        public bool Delete(int id);
        public List<Articulo> GetAll();
        bool Editar ( Articulo oArticulo);
       
    }
}
