using Microsoft.EntityFrameworkCore;
using Backend1.Model;

namespace Backend.DataAccess
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options)
            : base(options)
        {
        }

        public DbSet<Report> Reports { get; set; }
    }
}
