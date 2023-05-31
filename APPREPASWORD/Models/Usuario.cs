using System;
using System.Collections.Generic;

namespace APPREPASWORD.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            
        }

        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int? Documento { get; set; }
        public string? Cargo { get; set; }
        public int? IdRol { get; set; }
        public int? IdArea { get; set; }
        public int? Telefono { get; set; }
        public string? Correo { get; set; }
        public int? IdEstado { get; set; }
        public int? Fecha { get; set; }

        public virtual Area? IdAreaNavigation { get; set; }
        public virtual Estado? IdEstadoNavigation { get; set; }
        public virtual Rol? IdRolNavigation { get; set; }
       
    }
}
