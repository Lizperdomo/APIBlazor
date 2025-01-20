using System;
using System.Collections.Generic;

namespace AsistenciasCrud.Server.Models;

public partial class Horario
{
    public int IdHorario { get; set; }

    public int IdUsuario { get; set; }

    public TimeOnly HoraInicial { get; set; }

    public TimeOnly HoraFinal { get; set; }

    public string DiasLaborales { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
