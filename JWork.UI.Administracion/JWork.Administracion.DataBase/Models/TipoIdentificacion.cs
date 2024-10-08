﻿using SQLite;
using System.ComponentModel.DataAnnotations;

namespace JWork.UI.Administracion.DataBase.Models;

[Table("TipoIdentificacion")]
public class TipoIdentificacion
{
    [Key]
    public int TipoIdentificacionId { get; set; }
    public string Sigla { get; set; } = null!;
    public string Nombre { get; set; } = null!;
}

