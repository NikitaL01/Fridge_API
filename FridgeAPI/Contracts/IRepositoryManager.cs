namespace Contracts
{
    public interface IRepositoryManager
    {
        IFridgeRepository Fridge { get; }

        IFridgeModelRepository FridgeModel { get; }

        IFridgeProductRepository FridgeProducts { get; }

        IProductRepository Products { get; }

        Task SaveAsync();
    }
}
