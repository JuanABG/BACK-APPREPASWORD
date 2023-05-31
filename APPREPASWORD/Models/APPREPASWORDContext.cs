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

        public virtual DbSet<Acceso> Accesos { get; set; } = null!;
        public virtual DbSet<Ambiente> Ambientes { get; set; } = null!;
        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<Detalle> Detalles { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Historial> Historials { get; set; } = null!;
        public virtual DbSet<Repositorio> Repositorios { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Servidor> Servidors { get; set; } = null!;
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
            modelBuilder.Entity<Acceso>(entity =>
            {
                entity.ToTable("Acceso");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Ambiente>(entity =>
            {
                entity.ToTable("Ambiente");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Detalle>(entity =>
            {
                entity.ToTable("Detalle");

                entity.Property(e => e.Detalle1)
                    .HasMaxLength(50)
                    .HasColumnName("Detalle");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estado");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Historial>(entity =>
            {
                entity.ToTable("Historial");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Comentarios).HasMaxLength(50);

                entity.Property(e => e.FechaCreacionRegistro)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Creacion_Registro");

                entity.Property(e => e.FechaNovedad)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Novedad");

                entity.Property(e => e.IdAcceso).HasColumnName("Id_Acceso");

                entity.Property(e => e.IdAmbiente).HasColumnName("Id_Ambiente");

                entity.Property(e => e.IdDetalleRegistro).HasColumnName("Id_Detalle_Registro");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");

                entity.Property(e => e.IdServidor).HasColumnName("Id_Servidor");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.NombreAcceso)
                    .HasMaxLength(50)
                    .HasColumnName("Nombre_Acceso");

                entity.Property(e => e.RutaAcceso)
                    .HasMaxLength(50)
                    .HasColumnName("Ruta_Acceso");

                entity.Property(e => e.Usuario).HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.HistorialIdNavigation)
                    .HasForeignKey<Historial>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Historial_Repositorio");

                entity.HasOne(d => d.IdDetalleRegistroNavigation)
                    .WithMany(p => p.Historials)
                    .HasForeignKey(d => d.IdDetalleRegistro)
                    .HasConstraintName("FK_Historial_Detalle");

      
            });

            modelBuilder.Entity<Repositorio>(entity =>
            {
                entity.HasKey(e => e.IdRepositorio);

                entity.ToTable("Repositorio");

                entity.Property(e => e.IdRepositorio).HasColumnName("Id_Repositorio");

                entity.Property(e => e.Contraseña).HasMaxLength(50);

                entity.Property(e => e.FechaCreacionRegistro)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Creacion_Registro");

                entity.Property(e => e.IdAcceso).HasColumnName("Id_Acceso");

                entity.Property(e => e.IdAmbiente).HasColumnName("Id_Ambiente");

                entity.Property(e => e.IdDetalleRegistro).HasColumnName("Id_Detalle_Registro");

                entity.Property(e => e.IdServidor).HasColumnName("Id_Servidor");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.NombreAcceso)
                    .HasMaxLength(50)
                    .HasColumnName("Nombre_Acceso");

                entity.Property(e => e.RutaAcceso)
                    .HasMaxLength(50)
                    .HasColumnName("Ruta_Acceso");

                entity.Property(e => e.Usuario).HasMaxLength(50);

                entity.HasOne(d => d.IdAccesoNavigation)
                    .WithMany(p => p.Repositorios)
                    .HasForeignKey(d => d.IdAcceso)
                    .HasConstraintName("FK_Repositorio_Acceso");

                entity.HasOne(d => d.IdAmbienteNavigation)
                    .WithMany(p => p.Repositorios)
                    .HasForeignKey(d => d.IdAmbiente)
                    .HasConstraintName("FK_Repositorio_Ambiente");

                entity.HasOne(d => d.IdDetalleRegistroNavigation)
                    .WithMany(p => p.Repositorios)
                    .HasForeignKey(d => d.IdDetalleRegistro)
                    .HasConstraintName("FK_Repositorio_Detalle");

                entity.HasOne(d => d.IdServidorNavigation)
                    .WithMany(p => p.Repositorios)
                    .HasForeignKey(d => d.IdServidor)
                    .HasConstraintName("FK_Repositorio_Servidor");


            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Servidor>(entity =>
            {
                entity.ToTable("Servidor");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Apellidos).HasMaxLength(50);

                entity.Property(e => e.Cargo).HasMaxLength(50);

                entity.Property(e => e.Correo).HasMaxLength(50);

                entity.Property(e => e.IdArea).HasColumnName("Id_Area");

                entity.Property(e => e.IdEstado).HasColumnName("Id_Estado");

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("FK_Usuario_Area");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK_Usuario_Estado");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
