using System;
using System.Collections.Generic;

namespace gecu_API.Models;

public partial class Traza
{
    public int IdTraza { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public int UsuarioCreador { get; set; }

    public virtual Usuario UsuarioCreadorNavigation { get; set; } = null!;
}
