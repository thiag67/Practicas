using ArticulosBack.Models;
using ArticulosBack.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace proyecto_Practica02_.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
    public class FacturasController
    {
        private readonly FacturasManager aplicacion;
            public FacturasController()
            {
                aplicacion = new FacturasManager();
            }

            [HttpGet("Buscar Todos")]
            public IActionResult GetArticulos()
            {
                return Ok(aplicacion.GetAll());
            }
            [HttpPost("Agregar")]
            public IActionResult PostArticulos(Factura factura)
            {
                var result = aplicacion.Save(factura);
                return Ok(result);
            }
            [HttpDelete("Borrar")]
            public IActionResult Delete(int codigo)
            {
                var result = aplicacion.Delete(codigo);
                return Ok(result);
            }
            [HttpPut("Editar")]
            public IActionResult Editar(Articulo articulo)
            {
                var result = aplicacion.Editar(articulo);
                return Ok(result);
            }

        }
    }
