using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class Cargo
{
    public int IdCargo { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Solicitud> Solicituds { get; } = new List<Solicitud>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
