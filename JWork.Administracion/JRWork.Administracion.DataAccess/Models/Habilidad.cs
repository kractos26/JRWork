﻿using System;
using System.Collections.Generic;

namespace JRWork.Administracion.DataAccess.Models;

public partial class Habilidad
{
    public int HabilidadId { get; set; }

    public string? Nombre { get; set; }

    public int? ActividadId { get; set; }

    public virtual Actividad? Actividad { get; set; }
}
