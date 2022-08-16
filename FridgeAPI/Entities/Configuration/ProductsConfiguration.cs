using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    internal class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasData
                (
                    new Products
                    {
                        Id = new Guid("7ac83035-17e7-4a9d-89ef-a7e2b14e931b"),
                        Name = "Apple",
                        DefaultQuantity = 3
                    },
                    new Products
                    {
                        Id = new Guid("5c6d012b-dc74-4580-9716-141de40af83d"),
                        Name = "Water",
                        DefaultQuantity = 1
                    },
                    new Products
                    {
                        Id = new Guid("6f377e69-b477-463a-a874-763660787941"),
                        Name = "Eggs",
                        DefaultQuantity = 10
                    },
                    new Products
                    {
                        Id = new Guid("394c70b6-53c7-4b0a-bf98-a1bbd7c3c5c5"),
                        Name = "Milk",
                        DefaultQuantity = 1
                    },
                    new Products
                    {
                        Id = new Guid("3080f5cf-523e-405c-80e4-75d468a1a94e"),
                        Name = "Orange",
                        DefaultQuantity = 2
                    }
                );
        }
    }
}
