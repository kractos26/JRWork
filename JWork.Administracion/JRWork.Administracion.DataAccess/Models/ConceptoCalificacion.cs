using System;
using System.Collections.Generic;

namespace JRWork.Administracion.DataAccess.Models;

public partial class ConceptoCalificacion
{
    public int ConceptoCalificacionId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }
}
