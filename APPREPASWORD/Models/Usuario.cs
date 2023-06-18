using System;
using System.Collections.Generic;

namespace APPREPASWORD.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Historials = new HashSet<Historial>();
            Repositorios = new HashSet<Repositorio>();
        }

        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Documento { get; set; }
        public string? Cargo { get; set; }
        public string? Rol { get; set; }
        public string? Area { get; set; }
        public int? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Estado { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual ICollection<Historial> Historials { get; set; }
        public virtual ICollection<Repositorio> Repositorios { get; set; }
    }
}
