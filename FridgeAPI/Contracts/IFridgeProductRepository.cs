using Entities.Models;

namespace Contracts
{
    public interface IFridgeProductRepository
    {
        Task<IEnumerable<FridgeProduct>> GetFridgeProductsAsync(bool trackChanges);

        Task<FridgeProduct> GetFridgeProductAsync(Guid fridgeProductId, bool trackChanges);

        void CreateFridgeProduct(FridgeProduct fridgeProduct);

        void DeleteFridgeProduct(FridgeProduct fridgeProduct);
    }
}
