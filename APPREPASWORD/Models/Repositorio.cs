using System;
using System.Collections.Generic;

namespace APPREPASWORD.Models
{
    public partial class Repositorio
    {
        public Repositorio()
        {
            Historials = new HashSet<Historial>();
        }

        public int IdRepositorio { get; set; }
        public DateTime? FechaCreacionRegistro { get; set; }
        public int? IdUsuario { get; set; }
        public string? Acceso { get; set; }
        public string? Ambiente { get; set; }
        public string? Servidor { get; set; }
        public string? NombreAcceso { get; set; }
        public string? Usuario { get; set; }
        public string? Contraseña { get; set; }
        public string? RutaAcceso { get; set; }
        public string? DetalleRegistro { get; set; }
        public string? Estado { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<Historial> Historials { get; set; }
    }
}
