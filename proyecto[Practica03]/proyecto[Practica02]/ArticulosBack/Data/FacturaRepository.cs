﻿using ArticulosBack.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosBack.Data
{
    internal class FacturaRepository: IFacturaRepository
    {
        public List<Factura> GetAll()
        {
            List<Factura> lista = new List<Factura>();
            Factura? oFactura = null;
            DataTable tabla = DBHelper.GetInstance().ExecuteSPQuery("SP_RecuperarFacturas", null);
            foreach (DataRow row in tabla.Rows)
            {
                if (oFactura == null)
                {
                    oFactura = new Factura();
                    oFactura.Cliente = row["Cliente"].ToString();
                    oFactura.Codigo = (int)row["ID_Factura"];
                    oFactura.MetodoPago = (int)row["ID_MetodoPago"];
                    oFactura.Fecha = Convert.ToDateTime(row["Fecha"]);
                    oFactura.AddDetalle(ReadDetail(row));
                    lista.Add(oFactura);
                }
                else
                {
                    oFactura.AddDetalle(ReadDetail(row));
                }
            }
            return lista;
        }
        public Factura? GetByID(int id)
        {
            Factura? oFactura = null;
            List<ParametroSQL> parametros = new List<ParametroSQL>() { new ParametroSQL("@codigo", id) };
            DataTable tabla = DBHelper.GetInstance().ExecuteSPQuery("SP_RecuperarFacturas_Codigo", parametros);
            foreach (DataRow row in tabla.Rows)
            {
                if (oFactura == null)
                {
                    oFactura = new Factura();
                    oFactura.Cliente = row["Cliente"].ToString();
                    oFactura.Codigo = (int)row["ID_Factura"];
                    oFactura.MetodoPago = (int)row["ID_MetodoPago"];
                    oFactura.Fecha = Convert.ToDateTime(row["Fecha"]);
                    oFactura.AddDetalle(ReadDetail(row));
                }
                else
                {
                    oFactura.AddDetalle(ReadDetail(row));
                }
            }
            return oFactura;
        }
        private DetalleFactura ReadDetail(DataRow row)
        {
            DetalleFactura detalle = new DetalleFactura();
            detalle.Precio = (float)row["Precio"];
            detalle.Cantidad = (int)row["Cantidad"];
            detalle.Producto = new Articulo
            {
                Codigo = (int)row["ID_Producto"],
                Nombre = row["Nombre"].ToString(),
                Precio = (decimal)row["PrecioProducto"],
                Activo = Convert.ToBoolean(row["Activo"])
            };
            return detalle;
        }

        public bool Save(Factura oFactura)
        {
            SqlConnection connection = DBHelper.GetInstance().GetConnection();
            connection.Open();
            SqlTransaction Transaccion = connection.BeginTransaction();
            List<ParametroSQL> parametros = new List<ParametroSQL>()
            {
                new ParametroSQL("@cliente",oFactura.Cliente),
                new ParametroSQL("@metodopago",oFactura.MetodoPago),
                new ParametroSQL("@id",System.Data.SqlDbType.Int)
            };
            List<ParametroSQL> Output = new List<ParametroSQL>();
            if (DBHelper.GetInstance().ExecuteSPDMLTransact("SP_GuardarFactura", connection, Transaccion, parametros, out Output) == 0)
            {
                Console.WriteLine("Error al cargar maestro");
                return false;
            };

            int IDMaestro = (int)Output[0].Valor;
            int nroDetalle = 1;
            foreach (var detalle in oFactura.GetDetalles())
            {
                List<ParametroSQL> parametrosdetalle = new List<ParametroSQL>()
                {
                    new ParametroSQL("@detalle",nroDetalle),
                    new ParametroSQL("@factura",IDMaestro),
                    new ParametroSQL("@producto",detalle.Producto.Codigo),
                    new ParametroSQL("@cantidad",detalle.Cantidad),
                    new ParametroSQL("@precio",detalle.Precio)
                };
                if (DBHelper.GetInstance().ExecuteSPDMLTransact("SP_GuardarDetalle", connection, Transaccion, parametrosdetalle) == 0)
                {
                    Console.WriteLine("Error al cargar detalle");
                    return false;
                };
                nroDetalle++;
            }
            Transaccion.Commit();
            connection.Close();
            return true;
        }


    }
}

