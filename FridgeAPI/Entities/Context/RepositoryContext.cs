using Entities.Configuration;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities.Context
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FridgeConfiguration());
            modelBuilder.ApplyConfiguration(new FridgeModelConfiguration());
            modelBuilder.ApplyConfiguration(new FridgeProductsConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Fridge>? Fridge { get; set; }

        public DbSet<FridgeModel>? FridgeModels { get; set; }

        public DbSet<FridgeProducts>? FridgeProducts { get; set; }

        public DbSet<Products>? Products { get; set; }
    }
}
