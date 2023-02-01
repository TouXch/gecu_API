using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class SolicitudmMtipo
{
    public int Id { get; set; }

    public int IdSolicitud { get; set; }

    public int IdTipoSolicitud { get; set; }

    public virtual Solicitud IdSolicitudNavigation { get; set; } = null!;

    public virtual TipoSolicitud IdTipoSolicitudNavigation { get; set; } = null!;
}
