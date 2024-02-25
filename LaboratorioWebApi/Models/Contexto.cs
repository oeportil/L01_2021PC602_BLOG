using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;  

namespace LaboratorioWebApi.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        {
        
        
        }
    }
}
