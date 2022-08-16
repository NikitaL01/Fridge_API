namespace Entities.DataTransferObjects
{
    public class ProductsDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public int DefaultQuantity { get; set; }
    }
}
