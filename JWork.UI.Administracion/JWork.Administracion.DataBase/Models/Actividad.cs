﻿using SQLite;
using System.ComponentModel.DataAnnotations;

namespace JWork.UI.Administracion.DataBase.Models;

[Table("Actividad")]
public partial class Actividad
{
    [Key]
    public int ActividadId { get; set; }

    public string Nombre { get; set; } = null!;

    public int? OficioId { get; set; }

    public virtual ICollection<Habilidad> Habilidads { get; set; } = new List<Habilidad>();

    public virtual Oficio? Oficio { get; set; }
}
