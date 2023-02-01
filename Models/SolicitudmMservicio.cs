using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class SolicitudmMservicio
{
    public int Id { get; set; }

    public int IdSolicitud { get; set; }

    public int IdServicio { get; set; }

    public virtual TipoServicio IdServicioNavigation { get; set; } = null!;

    public virtual Solicitud IdSolicitudNavigation { get; set; } = null!;
}
