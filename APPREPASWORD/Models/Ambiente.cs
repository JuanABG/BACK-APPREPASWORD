using System;
using System.Collections.Generic;

namespace APPREPASWORD.Models
{
    public partial class Ambiente
    {
        public Ambiente()
        {
            Repositorios = new HashSet<Repositorio>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Repositorio> Repositorios { get; set; }
    }
}
