using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaboratorioWebApi.Models;

public partial class Roles
{
    [Key]
    public int RolId { get; set; }

    public string? Rol { get; set; }
}
