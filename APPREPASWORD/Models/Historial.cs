using System;
using System.Collections.Generic;

namespace APPREPASWORD.Models
{
    public partial class Historial
    {
        public int Id { get; set; }
        public DateTime? FechaNovedad { get; set; }
        public int? IdRegistro { get; set; }
        public string? FechaCreacionRegistro { get; set; }
        public int? IdUsuario { get; set; }
        public string? Acceso { get; set; }
        public string? Ambiente { get; set; }
        public string? Servidor { get; set; }
        public string? NombreAcceso { get; set; }
        public string? RutaAcceso { get; set; }
        public string? Usuario { get; set; }
        public string? DetalleRegistro { get; set; }
        public string? Estado { get; set; }
        public string? Comentarios { get; set; }

        public virtual Repositorio? IdRegistroNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
