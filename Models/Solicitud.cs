using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class Solicitud
{
    public int IdSolicitud { get; set; }

    public DateTime FechaSolicitud { get; set; }

    public int UsuarioCreador { get; set; }

    public int EstadoSolicitud { get; set; }

    public virtual EstadoSolicitud EstadoSolicitudNavigation { get; set; } = null!;

    public virtual ICollection<SolicitudmMaplicacion> SolicitudmMaplicacions { get; } = new List<SolicitudmMaplicacion>();

    public virtual ICollection<SolicitudmMservicio> SolicitudmMservicios { get; } = new List<SolicitudmMservicio>();

    public virtual ICollection<SolicitudmMtipo> SolicitudmMtipos { get; } = new List<SolicitudmMtipo>();

    public virtual Usuario UsuarioCreadorNavigation { get; set; } = null!;
}
