using System;
using System.Collections.Generic;

namespace APPREPASWORD.Models
{
    public partial class Repositorio
    {
        public Repositorio()
        {
         
        }

        public int IdRepositorio { get; set; }
        public DateTime? FechaCreacionRegistro { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdAcceso { get; set; }
        public int? IdAmbiente { get; set; }
        public int? IdServidor { get; set; }
        public string? NombreAcceso { get; set; }
        public string? Usuario { get; set; }
        public string? Contraseña { get; set; }
        public string? RutaAcceso { get; set; }
        public int? IdDetalleRegistro { get; set; }

        public virtual Acceso? IdAccesoNavigation { get; set; }
        public virtual Ambiente? IdAmbienteNavigation { get; set; }
        public virtual Detalle? IdDetalleRegistroNavigation { get; set; }
        public virtual Servidor? IdServidorNavigation { get; set; }
        
        public virtual Historial HistorialIdNavigation { get; set; } = null!;
        
    }
}
