using System;
using System.Collections.Generic;

namespace JRWork.Administracion.DataAccess.Models;

public partial class Area
{
    public int AreaId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Oficio> Oficios { get; set; } = new List<Oficio>();
}
