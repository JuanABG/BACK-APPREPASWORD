using System;
using System.Collections.Generic;

namespace APPREPASWORD.Models
{
    public partial class Historial
    {
        public int Id { get; set; }
        public DateTime? FechaNovedad { get; set; }
        public int? IdRegistro { get; set; }
        public DateTime? FechaCreacionRegistro { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdAcceso { get; set; }
        public int? IdAmbiente { get; set; }
        public int? IdServidor { get; set; }
        public string? NombreAcceso { get; set; }
        public string? RutaAcceso { get; set; }
        public string? Usuario { get; set; }
        public int? IdDetalleRegistro { get; set; }
        public string? Comentarios { get; set; }

        public virtual Detalle? IdDetalleRegistroNavigation { get; set; }
        public virtual Repositorio IdNavigation { get; set; } = null!;
       
    }
}
