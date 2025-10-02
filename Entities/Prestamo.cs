using System;
using System.Collections.Generic;

namespace Biblioteca_Virtual.Entities;

public partial class Prestamo
{
    public int Id { get; set; }

    public short? IdUsuario { get; set; }

    public DateTime? FechaPrestamo { get; set; }

    public bool? Cancelado { get; set; }

    public DateTime? FechaCancelacion { get; set; }

    public short? CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? UltimaActualizacion { get; set; }

    public bool? Activo { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<PrestamoEjemplar> PrestamoEjemplares { get; set; } = new List<PrestamoEjemplar>();
}
