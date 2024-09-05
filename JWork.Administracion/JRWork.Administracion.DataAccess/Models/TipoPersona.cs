using System;
using System.Collections.Generic;

namespace JRWork.Administracion.DataAccess.Models;

public partial class TipoPersona
{
    public int TipoPersonaId { get; set; }

    public string Nombre { get; set; } = null!;
}
