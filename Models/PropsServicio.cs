using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class PropsServicio
{
    public int IdPropServicio { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? IdTipoServicio { get; set; }

    public virtual TipoServicio? IdTipoServicioNavigation { get; set; }
}
