using System;
using System.Collections.Generic;

namespace Biblioteca_Virtual.Entities;

public partial class Estado
{
    public int Id { get; set; }

    public int? IdEjemplar { get; set; }

    public string? Observacion { get; set; }

    public DateTime? FechaDescripcion { get; set; }

    public short? CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? UltimaActualizacion { get; set; }

    public bool? Activo { get; set; }

    public virtual Ejemplar? IdEjemplarNavigation { get; set; }
}
