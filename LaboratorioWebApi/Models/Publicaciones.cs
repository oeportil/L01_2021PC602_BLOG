using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaboratorioWebApi.Models;

public partial class Publicaciones
{
    [Key]
    public int PublicacionId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int? UsuarioId { get; set; }
}
