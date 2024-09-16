﻿namespace JWork.UI.Administracion.Models;

public class DivipolaDto
{
    public int DivipolaId { get; set; }

    public decimal Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal? CodigoPadre { get; set; }
}
