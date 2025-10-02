using System;
using System.Collections.Generic;

namespace Biblioteca_Virtual.Entities;

public partial class Categoria
{
    public sbyte Id { get; set; }

    public string? Nombre { get; set; }

    public short? CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? UltimaActualizacion { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Libro> IdLibros { get; set; } = new List<Libro>();
}
