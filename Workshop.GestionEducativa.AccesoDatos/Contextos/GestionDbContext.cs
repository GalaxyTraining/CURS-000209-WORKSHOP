using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Workshop.GestionEducativa.AccesoDatos;
using Workshop.GestionEducativa.Entidades;

namespace Workshop.GestionEducativa.AccesoDatos.Contextos;

public partial class GestionDbContext : DbContext
{
    public GestionDbContext()
    {
    }

    public GestionDbContext(DbContextOptions<GestionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Apoderado> Apoderados { get; set; }

    public virtual DbSet<Grado> Grados { get; set; }

    public virtual DbSet<Matricula> Matriculas { get; set; }

    public virtual DbSet<Periodoescolar> Periodoescolars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("alumno_pkey");

            entity.ToTable("alumno");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fechanacimiento).HasColumnName("fechanacimiento");
            entity.Property(e => e.Fecharegistro).HasColumnName("fecharegistro");
            entity.Property(e => e.Idapoderado).HasColumnName("idapoderado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Numerodocumento)
                .HasMaxLength(15)
                .HasColumnName("numerodocumento");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdapoderadoNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.Idapoderado)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("alumno_idapoderado_fkey");
        });

        modelBuilder.Entity<Apoderado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("apoderado_pkey");

            entity.ToTable("apoderado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");
            entity.Property(e => e.Celular)
                .HasMaxLength(100)
                .HasColumnName("celular");
            entity.Property(e => e.Correoelectronico)
                .HasMaxLength(100)
                .HasColumnName("correoelectronico");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecharegistro).HasColumnName("fecharegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Numerodocumento)
                .HasMaxLength(15)
                .HasColumnName("numerodocumento");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasColumnName("usuarioregistro");
        });

        modelBuilder.Entity<Grado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("grado_pkey");

            entity.ToTable("grado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecharegistro).HasColumnName("fecharegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasColumnName("usuarioregistro");
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("matricula_pkey");

            entity.ToTable("matricula");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecharegistro).HasColumnName("fecharegistro");
            entity.Property(e => e.Idalumno).HasColumnName("idalumno");
            entity.Property(e => e.Idgrado).HasColumnName("idgrado");
            entity.Property(e => e.Idperiodoescolar).HasColumnName("idperiodoescolar");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdalumnoNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.Idalumno)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("matricula_idalumno_fkey");

            entity.HasOne(d => d.IdgradoNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.Idgrado)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("matricula_idgrado_fkey");

            entity.HasOne(d => d.IdperiodoescolarNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.Idperiodoescolar)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("matricula_idperiodoescolar_fkey");
        });

        modelBuilder.Entity<Periodoescolar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("periodoescolar_pkey");

            entity.ToTable("periodoescolar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fechafin).HasColumnName("fechafin");
            entity.Property(e => e.Fechainicio).HasColumnName("fechainicio");
            entity.Property(e => e.Fecharegistro).HasColumnName("fecharegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Periodo)
                .HasMaxLength(50)
                .HasColumnName("periodo");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasColumnName("usuarioregistro");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
