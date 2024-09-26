using JWork.UI.Administracion.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JWork.UI.Administracion.DataBase.Models;

public partial class JWorkContext(IDatabaseRutaService databaseRuta) : DbContext
{
    private readonly IDatabaseRutaService _databaseRuta = databaseRuta;
    public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        try
        {
            if(!optionsBuilder.IsConfigured)
            {
                string ruta = _databaseRuta.GetRuta("jwork.db");
                string conexion = $"Data Source = {ruta}";
                optionsBuilder.UseSqlite(conexion).EnableSensitiveDataLogging();
            }
           
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al escribir en la ruta: {ex.Message}");
        }

        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Definir las tablas sin esquema
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.ActividadId).HasName("PK_Actividad");
            entity.ToTable("Actividad");
            entity.Property(e => e.Nombre).HasMaxLength(20);
            entity.HasOne(d => d.Oficio)
                  .WithMany(p => p.Actividads)
                  .HasForeignKey(d => d.OficioId)
                  .HasConstraintName("FK_Actividad_Oficio");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK_Area");
            entity.ToTable("Area");
            entity.Property(e => e.Nombre).HasMaxLength(10);
        });

        modelBuilder.Entity<ConceptoCalificacion>(entity =>
        {
            entity.HasKey(e => e.ConceptoCalificacionId).HasName("PK_ConceptoCalificacion");
            entity.ToTable("ConceptoCalificacion");
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Nombre).HasMaxLength(200);
        });

        modelBuilder.Entity<Divipola>(entity =>
        {
            entity.HasKey(e => e.DivipolaId).HasName("PK_Divipola");
            entity.ToTable("Divipola");
            entity.Property(e => e.Codigo).HasColumnType("real");  // Ajustar para SQLite
            entity.Property(e => e.CodigoPadre).HasColumnType("real");
            entity.Property(e => e.Nombre).HasMaxLength(24);
        });

        modelBuilder.Entity<Habilidad>(entity =>
        {
            entity.HasKey(e => e.HabilidadId).HasName("PK_Habilidad");
            entity.ToTable("Habilidad");
            entity.Property(e => e.Nombre).HasMaxLength(20);
            entity.HasOne(d => d.Actividad)
                  .WithMany(p => p.Habilidads)
                  .HasForeignKey(d => d.ActividadId)
                  .HasConstraintName("FK_Habilidad_Actividad");
        });

        modelBuilder.Entity<Oficio>(entity =>
        {
            entity.HasKey(e => e.OficioId).HasName("PK_Oficio");
            entity.ToTable("Oficio");
            entity.Property(e => e.Nombre).HasMaxLength(20);
            entity.HasOne(d => d.Area)
                  .WithMany(p => p.Oficios)
                  .HasForeignKey(d => d.AreaId)
                  .HasConstraintName("FK_Oficio_Area");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.TipoDocumentoId).HasName("PK_TipoDocumento");
            entity.ToTable("TipoDocumento");
            entity.Property(e => e.Nombre).HasMaxLength(20);
        });

        modelBuilder.Entity<TipoPersona>(entity =>
        {
            entity.HasKey(e => e.TipoPersonaId).HasName("PK_TipoPersona");
            entity.ToTable("TipoPersona");
            entity.Property(e => e.Nombre).HasMaxLength(11);
        });

        modelBuilder.Entity<UnidadMedida>(entity =>
        {
            entity.HasKey(e => e.UnidadMedidaId).HasName("PK_UnidadMedida");
            entity.ToTable("UnidadMedida");
            entity.Property(e => e.Nombre).HasMaxLength(4);
        });

        modelBuilder.Entity<TipoIdentificacion>(entity =>
        {
            entity.HasKey(e => e.TipoIdentificacionId).HasName("PK_TipoIdentificacion");
            entity.ToTable("TipoIdentificacion");
            entity.Property(e => e.Nombre).HasMaxLength(24);
            entity.Property(e => e.Sigla).HasMaxLength(5);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
