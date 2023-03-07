using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class Direccion
{
    public int IdDireccion { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdEstado { get; set; }

    public virtual EstadosDireccione IdEstadoNavigation { get; set; } = null!;

    public virtual ICollection<Solicitud> Solicituds { get; } = new List<Solicitud>();
}
