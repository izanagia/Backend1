using Backend1.Model;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace Backend1.DataAccess
{
    public class BackendDbContext : DbContext
    {
         public BackendDbContext(DbContextOptions<BackendDbContext> options) 
                : base(options) 
            { 
            }
            public DbSet<Report> Reports { get; set; }
        
    }
}
