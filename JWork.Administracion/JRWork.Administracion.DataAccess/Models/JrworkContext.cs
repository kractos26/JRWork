using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace JRWork.Administracion.DataAccess.Models;

public partial class JrworkContext : DbContext
{
    public JrworkContext(DbContextOptions<JrworkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividad { get; set; }

    public virtual DbSet<Area> Area { get; set; }

    public virtual DbSet<ConceptoCalificacion> ConceptoCalificacions { get; set; }

    public virtual DbSet<Divipola> Divipola { get; set; }

    public virtual DbSet<Habilidad> Habilidad { get; set; }

    public virtual DbSet<Oficio> Oficio { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }

    public virtual DbSet<TipoPersona> TipoPersona { get; set; }

    public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }

    public virtual DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.ActividadId).HasName("PK__Activida__98148390F393D3E7");

            entity.ToTable("Actividad", "adm");

            entity.Property(e => e.Nombre).HasMaxLength(20);

            entity.HasOne(d => d.Oficio).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.OficioId)
                .HasConstraintName("oficio_fk");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Area__70B8204819106163");

            entity.ToTable("Area", "adm");

            entity.Property(e => e.Nombre).HasMaxLength(10);
        });

        modelBuilder.Entity<ConceptoCalificacion>(entity =>
        {
            entity.HasKey(e => e.ConceptoCalificacionId).HasName("PK__Concepto__02BDA26D855A1A9D");

            entity.ToTable("ConceptoCalificacion", "adm");

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Nombre).HasMaxLength(200);
        });

        modelBuilder.Entity<Divipola>(entity =>
        {
            entity.HasKey(e => e.DivipolaId).HasName("PK__Divipola__B5B505D3BC134CAE");

            entity.ToTable("Divipola", "adm");

            entity.Property(e => e.Codigo).HasColumnType("numeric(16, 0)");
            entity.Property(e => e.CodigoPadre).HasColumnType("numeric(16, 0)");
            entity.Property(e => e.Nombre).HasMaxLength(24);
        });

        modelBuilder.Entity<Habilidad>(entity =>
        {
            entity.HasKey(e => e.HabilidadId).HasName("PK__Habilida__7341FE22520E468B");

            entity.ToTable("Habilidad", "adm");

            entity.Property(e => e.Nombre).HasMaxLength(20);

            entity.HasOne(d => d.Actividad).WithMany(p => p.Habilidads)
                .HasForeignKey(d => d.ActividadId)
                .HasConstraintName("actividad_fk");
        });

        modelBuilder.Entity<Oficio>(entity =>
        {
            entity.HasKey(e => e.OficioId).HasName("PK__Oficio__6C7A97864E4E408E");

            entity.ToTable("Oficio", "adm");

            entity.Property(e => e.Nombre).HasMaxLength(20);

            entity.HasOne(d => d.Area).WithMany(p => p.Oficios)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("area_fk");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.TipoDocumentoId).HasName("PK__TipoDocu__A329EA875F52CF1B");

            entity.ToTable("TipoDocumento", "adm");

            entity.Property(e => e.Nombre).HasMaxLength(20);
        });

        modelBuilder.Entity<TipoPersona>(entity =>
        {
            entity.HasKey(e => e.TipoPersonaId).HasName("PK__TipoPers__485B78C8143FCD79");

            entity.ToTable("TipoPersona", "adm");

            entity.Property(e => e.Nombre).HasMaxLength(11);
        });

        modelBuilder.Entity<UnidadMedida>(entity =>
        {
            entity.HasKey(e => e.UnidadMedidaId).HasName("PK__UnidadMe__339728610A12D95F");

            entity.ToTable("UnidadMedida", "adm");

            entity.Property(e => e.Nombre).HasMaxLength(4);
        });

        modelBuilder.Entity<TipoIdentificacion>(entity =>
        {
            entity.HasKey(e => e.TipoIdentificacionId).HasName("PK__TipoDocu__A329EA87F15F2D84");
            entity.ToTable("TipoIdentificacion", "adm");
            entity.Property(e => e.Nombre).HasMaxLength(24);
            entity.Property(e=>e.Sigla).HasMaxLength(5);
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
