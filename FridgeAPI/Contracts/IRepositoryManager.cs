namespace Contracts
{
    public interface IRepositoryManager
    {
        IFridgeRepository Fridge { get; }

        IFridgeModelRepository FridgeModel { get; }

        IFridgeProductsRepository FridgeProducts { get; }

        IProductsRepository Products { get; }

        Task SaveAsync();
    }
}
