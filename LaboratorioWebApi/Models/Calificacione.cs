﻿using System;
using System.Collections.Generic;

namespace LaboratorioWebApi.Models;

public partial class Calificacione
{
    public int CalificacionId { get; set; }

    public int? PublicacionId { get; set; }

    public int? UsuarioId { get; set; }

    public int? Calificacion { get; set; }
}
