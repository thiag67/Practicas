using ArticulosBack.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosBack.Data
{
    internal class ArticuloRepository: IArticuloRepository
    {
        public bool Editar(Articulo oArticulo)
        {
            var parametros = new List<ParametroSQL>()
    {
        new ParametroSQL("@codigo", oArticulo.Codigo),
        new ParametroSQL("@nombre", oArticulo.Nombre),
        new ParametroSQL("@precio", oArticulo.Precio),
        new ParametroSQL("@stock", oArticulo.Stock),
        new ParametroSQL("@activo", oArticulo.Activo)
    };
            int rows = DBHelper.GetInstance().ExecuteSPDML("SP_EditarArticulo", parametros);
            return (rows == 1);
        }

        public bool Delete(int id)
        {
            var parametros = new List<ParametroSQL>();
            parametros.Add(new ParametroSQL("@codigo", id));
            int rows = DBHelper.GetInstance().ExecuteSPDML("SP_BorrarProducto", parametros);
            return (rows == 1);
        }

        public List<Articulo> GetAll()
        {
            List<Articulo> list = new List<Articulo>();
            DataTable tabla = DBHelper.GetInstance().ExecuteSPQuery("SP_RecuperarProductos", null);
            foreach (DataRow row in tabla.Rows)
            {
                Articulo oArticulo = new Articulo()
                {
                    Codigo = Convert.ToInt32(row["ID_Producto"]),
                    Nombre = row["Nombre"].ToString(),
                    Precio = (decimal)Convert.ToSingle(row["Precio"]),
                    Activo = Convert.ToBoolean(row["Activo"]),
                    Stock = Convert.ToInt32(row["Stock"])
                };
                list.Add(oArticulo);
            }
            return list;
        }

        public Articulo GetByID(int id)
        {
            var parametros = new List<ParametroSQL>();
            parametros.Add(new ParametroSQL("@codigo", id));
            DataTable tabla = DBHelper.GetInstance().ExecuteSPQuery("SP_RecuperarProducto_Codigo", parametros);
            if (tabla != null && tabla.Rows.Count == 1)
            {
                DataRow row = tabla.Rows[0];
                Articulo oArticulo = new Articulo()
                {
                    Codigo = Convert.ToInt32(row["ID_Producto"]),
                    Nombre = row["Nombre"].ToString(),
                    Precio = (decimal)Convert.ToSingle(row["Precio"]),
                    Activo = Convert.ToBoolean(row["Activo"]),
                    Stock = Convert.ToInt32(row["Stock"])
                };
                return oArticulo;
            }
            else
            {
                return null;
            }

        }

        public bool Agregar(Articulo oArticulo)
        {
            var parametros = new List<ParametroSQL>()
            {
                new ParametroSQL("@nombre",oArticulo.Nombre),
                new ParametroSQL("@precio",oArticulo.Precio),
                new ParametroSQL("@stock",oArticulo.Stock),
                new ParametroSQL("@activo",oArticulo.Activo),
            };
            int rows = DBHelper.GetInstance().ExecuteSPDML("SP_GuardarProducto", parametros);
            return (rows == 1);
        }
    }
}

