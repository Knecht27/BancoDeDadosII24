using Microsoft.EntityFrameworkCore;

namespace BTecpar.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Client> clients { get; set; }
        public DbSet<Adress> Adresses { get; set; }

    }
}


