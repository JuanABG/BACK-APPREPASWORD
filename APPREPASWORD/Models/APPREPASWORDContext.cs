using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APPREPASWORD.Models
{
    public partial class APPREPASWORDContext : DbContext
    {
        public APPREPASWORDContext()
        {
        }

        public APPREPASWORDContext(DbContextOptions<APPREPASWORDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Historial> Historials { get; set; } = null!;
        public virtual DbSet<Repositorio> Repositorios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=JUANABG\\ZERO; Database=APPREPASWORD; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Historial>(entity =>
            {
                entity.ToTable("Historial");

                entity.Property(e => e.Acceso).HasMaxLength(50);

                entity.Property(e => e.Ambiente).HasMaxLength(50);

                entity.Property(e => e.Comentarios).HasMaxLength(50);

                entity.Property(e => e.DetalleRegistro)
                    .HasMaxLength(50)
                    .HasColumnName("Detalle_Registro");

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.FechaCreacionRegistro)
                    .HasMaxLength(50)
                    .HasColumnName("Fecha_Creacion_Registro");

                entity.Property(e => e.FechaNovedad)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Novedad");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.NombreAcceso)
                    .HasMaxLength(50)
                    .HasColumnName("Nombre_Acceso");

                entity.Property(e => e.RutaAcceso)
                    .HasMaxLength(50)
                    .HasColumnName("Ruta_Acceso");

                entity.Property(e => e.Servidor).HasMaxLength(50);

                entity.Property(e => e.Usuario).HasMaxLength(50);

                entity.HasOne(d => d.IdRegistroNavigation)
                    .WithMany(p => p.Historials)
                    .HasForeignKey(d => d.IdRegistro)
                    .HasConstraintName("FK_Historial_Repositorios");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Historials)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Historial_Usuario");
            });

            modelBuilder.Entity<Repositorio>(entity =>
            {
                entity.HasKey(e => e.IdRepositorio);

                entity.Property(e => e.IdRepositorio).HasColumnName("Id_Repositorio");

                entity.Property(e => e.Acceso).HasMaxLength(50);

                entity.Property(e => e.Ambiente).HasMaxLength(50);

                entity.Property(e => e.Contraseña).HasMaxLength(50);

                entity.Property(e => e.DetalleRegistro)
                    .HasMaxLength(50)
                    .HasColumnName("Detalle_Registro");

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.FechaCreacionRegistro)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Creacion_Registro");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.NombreAcceso)
                    .HasMaxLength(50)
                    .HasColumnName("Nombre_Acceso");

                entity.Property(e => e.RutaAcceso)
                    .HasMaxLength(50)
                    .HasColumnName("Ruta_Acceso");

                entity.Property(e => e.Servidor).HasMaxLength(50);

                entity.Property(e => e.Usuario).HasMaxLength(50);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Repositorios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Repositorios_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Apellidos).HasMaxLength(50);

                entity.Property(e => e.Area).HasMaxLength(50);

                entity.Property(e => e.Cargo).HasMaxLength(50);

                entity.Property(e => e.Correo).HasMaxLength(50);

                entity.Property(e => e.Documento).HasMaxLength(50);

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.Rol).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
