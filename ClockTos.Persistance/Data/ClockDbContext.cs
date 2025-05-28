using ClockTos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClockTos.Persistance.Data
{
    public class ClockDbContext:DbContext
    {

        public ClockDbContext(DbContextOptions<ClockDbContext> context):base(context) 
        {
        
        }

        DbSet<Colleges> Colleges { get; set; }

        DbSet<Designations> Designations { get; set; }
    }
}
