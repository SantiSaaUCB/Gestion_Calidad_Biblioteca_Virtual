using System;
using System.Collections.Generic;

namespace Biblioteca_Virtual.Entities;

public partial class Editorial
{
    public short Id { get; set; }

    public string? Nombre { get; set; }

    public string? Pais { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? SitioWeb { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
