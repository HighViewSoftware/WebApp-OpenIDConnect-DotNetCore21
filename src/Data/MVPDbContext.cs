using BopodaMVP.Models;
using Microsoft.EntityFrameworkCore;

namespace BopodaMVP.Data
{
    public class MVPDbContext : DbContext
    {
        public MVPDbContext(DbContextOptions<MVPDbContext> options)
            : base(options)
        {

        }

        public DbSet<MVPUser> Users { get; set; }
    }
}
