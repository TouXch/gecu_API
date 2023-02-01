using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class TipoServicio
{
    public int IdTipoServicio { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<SolicitudmMservicio> SolicitudmMservicios { get; } = new List<SolicitudmMservicio>();
}
