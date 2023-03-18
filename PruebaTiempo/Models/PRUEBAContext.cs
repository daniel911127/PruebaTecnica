using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaTiempo.Models
{
    public partial class PRUEBAContext : DbContext
    {
        public PRUEBAContext()
        {
        }

        public PRUEBAContext(DbContextOptions<PRUEBAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Elemento> Elementos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Sucursale> Sucursales { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=PRUEBA;User ID=sa;pwd=060911; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Elemento>(entity =>
            {
                entity.HasKey(e => e.ElementId)
                    .HasName("PK__Elemento__846470F48F959F4F");

                entity.Property(e => e.ElementId).HasColumnName("Element_Id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Empleado__262359ABF8E21759");

                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SueldoBase).HasColumnName("Sueldo_Base");
            });

            modelBuilder.Entity<Sucursale>(entity =>
            {
                entity.HasKey(e => e.SucId)
                    .HasName("PK__Sucursal__5B93BA1EA49725F7");

                entity.Property(e => e.SucId).HasColumnName("Suc_Id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
