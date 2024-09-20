
using JRWork.UI.Administracion.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace JRWork.Administracion.DataAccess.Models;

public partial class JrworkContext : DbContext
{
   
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
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "jwork.db3");
        optionsBuilder.UseSqlite($"Filename={dbPath}");
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
