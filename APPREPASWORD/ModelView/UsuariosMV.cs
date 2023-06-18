using APPREPASWORD.Models;

namespace APPREPASWORD.ModelView
{
    public class UsuariosMV
    {
        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public String? Documento { get; set; }
        public string? NombreArea { get; set; }
        public string? Rol { get; set; }
        public string? Estado { get; set; }
        public string? Cargo { get; set; }
        public int? Telefono { get; set; }
        public string? Correo { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
