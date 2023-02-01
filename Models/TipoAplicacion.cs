using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class TipoAplicacion
{
    public int IdTipoAplicacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<SolicitudmMaplicacion> SolicitudmMaplicacions { get; } = new List<SolicitudmMaplicacion>();
}
