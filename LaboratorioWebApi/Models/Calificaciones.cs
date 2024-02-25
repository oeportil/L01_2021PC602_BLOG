using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaboratorioWebApi.Models;

public partial class Calificaciones
{
    [Key]
    public int CalificacionId { get; set; }

    public int? PublicacionId { get; set; }

    public int? UsuarioId { get; set; }

    public int? Calificacion { get; set; }
}
