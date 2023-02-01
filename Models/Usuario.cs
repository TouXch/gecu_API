﻿using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdContrato { get; set; }

    public int? IdCargo { get; set; }

    public long? CarnetIdentidad { get; set; }

    public int? IdRol { get; set; }

    public DateTime FechaContrato { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string UsuarioCorreo { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public sbyte Estado { get; set; }

    public virtual Cargo? IdCargoNavigation { get; set; }

    public virtual Contrato? IdContratoNavigation { get; set; }

    public virtual Role? IdRolNavigation { get; set; }

    public virtual ICollection<Solicitud> Solicituds { get; } = new List<Solicitud>();

    public virtual ICollection<Traza> Trazas { get; } = new List<Traza>();
}