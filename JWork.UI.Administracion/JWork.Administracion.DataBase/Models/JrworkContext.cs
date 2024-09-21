
using JRWork.UI.Administracion.DataAccess.Models;
using JWork.UI.Administracion.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace JRWork.Administracion.DataAccess.Models;

public partial class JrworkContext : DbContext
{
    private readonly IDatabaseRutaService _databaseRuta;
    public JrworkContext(IDatabaseRutaService databaseRuta)
    {
        _databaseRuta = databaseRuta;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string conexion = $"Filename = {_databaseRuta.GetRuta("jwork.db")}";
        optionsBuilder.UseSqlite(conexion);
        var context = new JrworkContext(_databaseRuta);
       var res = context.Database.EnsureCreated();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
