using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class Solicitud
{
    public int IdSolicitud { get; set; }

    public int? TipoSolicitud { get; set; }

    public int? UsuarioCreador { get; set; }

    public DateTime FechaSolicitud { get; set; }

    public int? EstadoSolicitud { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Direccion { get; set; }

    public long? CarnetIdentidad { get; set; }

    public int? Cargo { get; set; }

    public string Usuario { get; set; } = null!;

    public virtual Cargo? CargoNavigation { get; set; }

    public virtual Direccion? DireccionNavigation { get; set; }

    public virtual EstadoSolicitud? EstadoSolicitudNavigation { get; set; }

    public virtual ICollection<SolicitudmMaplicacion> SolicitudmMaplicacions { get; } = new List<SolicitudmMaplicacion>();

    public virtual ICollection<SolicitudmMservicio> SolicitudmMservicios { get; } = new List<SolicitudmMservicio>();

    public virtual ICollection<SolicitudmMtipo> SolicitudmMtipos { get; } = new List<SolicitudmMtipo>();

    public virtual TipoSolicitud? TipoSolicitudNavigation { get; set; }

    public virtual Usuario? UsuarioCreadorNavigation { get; set; }
}
