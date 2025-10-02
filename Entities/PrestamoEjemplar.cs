using System;
using System.Collections.Generic;

namespace Biblioteca_Virtual.Entities;

public partial class PrestamoEjemplar
{
    public int IdPrestamo { get; set; }

    public int IdEjemplar { get; set; }

    public DateTime? FechaLimite { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public bool? Devuelto { get; set; }

    public DateTime? UltimaActualizacion { get; set; }

    public bool? Activo { get; set; }

    public virtual Ejemplar IdEjemplarNavigation { get; set; } = null!;

    public virtual Prestamo IdPrestamoNavigation { get; set; } = null!;
}
