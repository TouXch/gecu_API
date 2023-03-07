using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class EstadosDireccione
{
    public int IdEstado { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Direccion> Direccions { get; } = new List<Direccion>();
}
