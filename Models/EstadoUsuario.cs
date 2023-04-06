using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class EstadoUsuario
{
    public int IdEstadoU { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
