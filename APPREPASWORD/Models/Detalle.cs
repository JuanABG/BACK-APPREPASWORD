using System;
using System.Collections.Generic;

namespace APPREPASWORD.Models
{
    public partial class Detalle
    {
        public Detalle()
        {
            Historials = new HashSet<Historial>();
            Repositorios = new HashSet<Repositorio>();
        }

        public int Id { get; set; }
        public string? Detalle1 { get; set; }

        public virtual ICollection<Historial> Historials { get; set; }
        public virtual ICollection<Repositorio> Repositorios { get; set; }
    }
}
