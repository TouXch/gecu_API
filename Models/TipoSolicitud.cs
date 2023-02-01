using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class TipoSolicitud
{
    public int IdTipoSolicitud { get; set; }

    public string Descripcion { get; set; } = null!;

    public sbyte RequiereConfirmacion { get; set; }

    public virtual ICollection<SolicitudmMtipo> SolicitudmMtipos { get; } = new List<SolicitudmMtipo>();
}
