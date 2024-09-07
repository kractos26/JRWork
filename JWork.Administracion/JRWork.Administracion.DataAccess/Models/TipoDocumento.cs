using System;
using System.Collections.Generic;

namespace JRWork.Administracion.DataAccess.Models;

public partial class TipoDocumento
{
    public int TipoDocumentoId { get; set; }

    public string Nombre { get; set; } = null!;
}
