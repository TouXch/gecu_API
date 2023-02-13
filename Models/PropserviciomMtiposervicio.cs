using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class PropserviciomMtiposervicio
{
    public int Id { get; set; }

    public int IdPropServicio { get; set; }

    public int IdTipoServicio { get; set; }

    public virtual PropsServicio IdPropServicioNavigation { get; set; } = null!;

    public virtual TipoServicio IdTipoServicioNavigation { get; set; } = null!;
}
