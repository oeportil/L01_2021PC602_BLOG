using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaboratorioWebApi.Models;

public partial class Usuarios
{
    [Key]
    public int UsuarioId { get; set; }

    public int? RolId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;
}
