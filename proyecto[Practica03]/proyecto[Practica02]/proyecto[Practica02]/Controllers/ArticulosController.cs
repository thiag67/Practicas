using ArticulosBack.Models;
using ArticulosBack.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace proyecto_Practica02_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly ArticuloManager aplicacion;
        public ArticulosController()
        {
            aplicacion = new ArticuloManager();
        }

        [HttpGet("Buscar Todos")]
        public IActionResult GetArticulos()
        {
            return Ok(aplicacion.GetAll());
        }
        [HttpPost("Agregar")]
        public IActionResult PostArticulos(Articulo articulo)
        {
            var result = aplicacion.Agregar(articulo);
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
