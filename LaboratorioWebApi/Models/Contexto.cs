using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;  

namespace LaboratorioWebApi.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        {
  
        }
        public virtual DbSet<Calificacione> Calificaciones { get; set; }

        public virtual DbSet<Comentario> Comentarios { get; set; }

        public virtual DbSet<Publicacione> Publicaciones { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
