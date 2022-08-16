using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    internal class FridgeConfiguration : IEntityTypeConfiguration<Fridge>
    {
        public void Configure(EntityTypeBuilder<Fridge> builder)
        {
            builder.HasData
                (
                    new Fridge
                    {
                        Id = new Guid("2b544aed-49ad-41f4-9372-8f2d9a9e6956"),
                        Name = "Bosch",
                        OwnerName = "Alex"
                    },
                    new Fridge
                    {
                        Id = new Guid("48691dc6-312c-48e5-bd0d-ff23c852b9b3"),
                        Name = "LG",
                        OwnerName = "Mike"
                    },
                    new Fridge
                    {
                        Id = new Guid("50e1549e-0bc1-4f8d-a21e-648738e3ecb9"),
                        Name = "VR",
                        OwnerName = "Nikita"
                    }
                );
        }
    }
}
