using System;
using System.Collections.Generic;

namespace JRWork.Administracion.DataAccess.Models;

public partial class Actividad
{
    public int ActividadId { get; set; }

    public string? Nombre { get; set; }

    public int? OficioId { get; set; }

    public virtual ICollection<Habilidad> Habilidads { get; set; } = new List<Habilidad>();

    public virtual Oficio? Oficio { get; set; }
}
