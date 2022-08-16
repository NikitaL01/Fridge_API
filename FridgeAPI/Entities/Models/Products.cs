using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("products")]
    public class Products
    {
        [Column("id", TypeName = "UNIQUEIDENTIFIER")]
        public Guid Id { get; set; }

        [Required]
        [Column("name", TypeName = "nvarchar(MAX)")]
        public string? Name { get; set; }

        [Column("default_quantity", TypeName = "int")]
        public int DefaultQuantity { get; set; }

        public ICollection<FridgeProducts>? FridgeProducts { get; set; }
    }
}
