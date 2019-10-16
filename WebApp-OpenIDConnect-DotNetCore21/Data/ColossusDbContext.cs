using Microsoft.EntityFrameworkCore;
using WebApp_OpenIDConnect_DotNetCore21.Models;

namespace WebApp_OpenIDConnect_DotNetCore21.Data
{
    public class ColossusDbContext : DbContext
    {
        public ColossusDbContext(DbContextOptions<ColossusDbContext> options)
            : base(options)
        {

        }

        public DbSet<ColossusUser> Users { get; set; }
    }
}
