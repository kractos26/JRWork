using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JRWork.Administracion.DataAccess.Models;

public partial class JrworkContext : DbContext
{
    public JrworkContext()
    {
    }

    public JrworkContext(DbContextOptions<JrworkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividads { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Habilidad> Habilidads { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoPersona> TipoPersonas { get; set; }

    public virtual DbSet<UnidadMedidum> UnidadMedida { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-7VA8NVM3\\JULIANDB;Initial Catalog=JRWork;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.ActividadId).HasName("PK__Activida__98148390F393D3E7");

            entity.ToTable("Actividad", "adm");

            entity.Property(e => e.Nombre).HasMaxLength(20);
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Area__70B8204819106163");

            entity.ToTable("Area", "adm");

            entity.Property(e => e.Nombre).HasMaxLength(10);
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

        modelBuilder.Entity<UnidadMedidum>(entity =>
        {
            entity.HasKey(e => e.UnidadMedidaId).HasName("PK__UnidadMe__339728610A12D95F");

            entity.ToTable("UnidadMedida", "adm");

            entity.Property(e => e.Nombre).HasMaxLength(4);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
