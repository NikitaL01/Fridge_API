using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    internal class FridgeProductConfiguration : IEntityTypeConfiguration<FridgeProduct>
    {
        public void Configure(EntityTypeBuilder<FridgeProduct> builder)
        {
            builder.HasData
                (
                    new FridgeProduct
                    {
                        Id = new Guid("7ad906f6-5740-4bb8-a7b3-d70134cec431"),
                        ProductId = new Guid("7ac83035-17e7-4a9d-89ef-a7e2b14e931b"),
                        FridgeId = new Guid("2b544aed-49ad-41f4-9372-8f2d9a9e6956"),
                        Quantuty = 2
                    },
                    new FridgeProduct
                    {
                        Id = new Guid("d6cb8731-b5a4-4ca6-9895-cab735417d93"),
                        ProductId = new Guid("5c6d012b-dc74-4580-9716-141de40af83d"),
                        FridgeId = new Guid("48691dc6-312c-48e5-bd0d-ff23c852b9b3"),
                        Quantuty = 3
                    },
                    new FridgeProduct
                    {
                        Id = new Guid("23ae3b61-067f-4c2a-88cb-11b6098712de"),
                        ProductId = new Guid("6f377e69-b477-463a-a874-763660787941"),
                        FridgeId = new Guid("48691dc6-312c-48e5-bd0d-ff23c852b9b3"),
                        Quantuty = 1
                    },
                    new FridgeProduct
                    {
                        Id = new Guid("e47f4bc8-60d7-4e59-b4c3-af50b7f732dc"),
                        ProductId = new Guid("394c70b6-53c7-4b0a-bf98-a1bbd7c3c5c5"),
                        FridgeId = new Guid("50e1549e-0bc1-4f8d-a21e-648738e3ecb9"),
                        Quantuty = 2
                    },
                    new FridgeProduct
                    {
                        Id = new Guid("bd22f93c-252c-4cd9-b23e-6c7345804f9c"),
                        ProductId = new Guid("3080f5cf-523e-405c-80e4-75d468a1a94e"),
                        FridgeId = new Guid("50e1549e-0bc1-4f8d-a21e-648738e3ecb9"),
                        Quantuty = 0
                    }
                );
        }
    }
}
