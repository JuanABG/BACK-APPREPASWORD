using System;
using System.Collections.Generic;

namespace APPREPASWORD.Models
{
    public partial class Area
    {
        public Area()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
