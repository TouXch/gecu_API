using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class PropsAplicacione
{
    public int IdPropAplicacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? IdTipoAplicacion { get; set; }

    public virtual TipoAplicacion? IdTipoAplicacionNavigation { get; set; }
}
