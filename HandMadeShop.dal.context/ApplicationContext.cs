using HandMadeShop.dal.entites;
using Microsoft.EntityFrameworkCore;

namespace HandMadeShop.dal.context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=HandMadeShop.db");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Toy> Toys { get; set; }
    }
}