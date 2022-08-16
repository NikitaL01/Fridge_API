using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    internal class FridgeModelConfiguration : IEntityTypeConfiguration<FridgeModel>
    {
        public void Configure(EntityTypeBuilder<FridgeModel> builder)
        {
            builder.HasData
                (
                    new FridgeModel
                    {
                        Id = new Guid("d098d69c-ff78-4f2a-bf7f-c9d343898963"),
                        FridgeId = new Guid("2b544aed-49ad-41f4-9372-8f2d9a9e6956"),
                        Name = "KGV39XW2AR",
                        Year = 2020
                    },
                    new FridgeModel
                    {
                        Id = new Guid("14ac0bdd-7e08-4d49-a439-6c4634529d74"),
                        FridgeId = new Guid("48691dc6-312c-48e5-bd0d-ff23c852b9b3"),
                        Name = "GA-B379SLUL",
                        Year = 2018
                    },
                    new FridgeModel
                    {
                        Id = new Guid("6a5845af-1c8b-4060-9f1c-70018a63cb09"),
                        FridgeId = new Guid("50e1549e-0bc1-4f8d-a21e-648738e3ecb9"),
                        Name = "FR-102V",
                        Year = 2017
                    }
                );
        }
    }
}
