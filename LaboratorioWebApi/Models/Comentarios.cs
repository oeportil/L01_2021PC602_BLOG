using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaboratorioWebApi.Models;

public partial class Comentarios
{
    [Key]
    public int CometarioId { get; set; }

    public int? PublicacionId { get; set; }

    public string? Comentario1 { get; set; }

    public int? UsuarioId { get; set; }
}
