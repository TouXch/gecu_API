using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class EstadoSolicitud
{
    public int IdEstadoSol { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Solicitud> Solicituds { get; } = new List<Solicitud>();
}
