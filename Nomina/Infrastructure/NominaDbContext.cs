using Microsoft.EntityFrameworkCore;
using Nomina.Domain;

namespace Nomina.Infrastructure
{
    public class NominaDbContext : DbContext
    {
        public NominaDbContext(DbContextOptions<NominaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}