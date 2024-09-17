namespace ArticulosBack.Models
{
    public class Articulo
    {
        public int Codigo { get; set; }
        public string? Nombre { get; set; }
        public decimal? Precio { get; set; }
        public  bool? Activo { get; set; }
        public int? Stock { get; set; }
    }
}
