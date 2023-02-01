using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class SolicitudmMaplicacion
{
    public int Id { get; set; }

    public int IdSolicitud { get; set; }

    public int IdAplicacion { get; set; }

    public virtual TipoAplicacion IdAplicacionNavigation { get; set; } = null!;

    public virtual Solicitud IdSolicitudNavigation { get; set; } = null!;
}
