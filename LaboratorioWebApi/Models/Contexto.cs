using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;  

namespace LaboratorioWebApi.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        {
  
        }
        public virtual DbSet<Calificaciones> Calificaciones { get; set; }

        public virtual DbSet<Comentarios> Comentarios { get; set; }

        public virtual DbSet<Publicaciones> Publicaciones { get; set; }

        public virtual DbSet<Roles> Roles { get; set; }

        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
