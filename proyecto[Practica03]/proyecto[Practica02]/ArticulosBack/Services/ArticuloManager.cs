using ArticulosBack.Data;
using ArticulosBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosBack.Services
{
    public class ArticuloManager
    {
        IArticuloRepository oIArticuloRepository;
        public ArticuloManager()
        {
            oIArticuloRepository = new ArticuloRepository();
        }
            
        public bool Agregar(Articulo oArticulo)
        {
        
           return oIArticuloRepository.Agregar(oArticulo);
        }
       public bool Delete(int id)
        {

            return oIArticuloRepository.Delete(id);
        }
        public List<Articulo> GetAll()
        {

            return oIArticuloRepository.GetAll();
        }
        public bool Editar(Articulo oArticulo)
        {

            return oIArticuloRepository.Editar(oArticulo);
        }
    }
}
