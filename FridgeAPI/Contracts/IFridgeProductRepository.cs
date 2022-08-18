using Entities.Models;

namespace Contracts
{
    public interface IFridgeProductRepository
    {
        Task<IEnumerable<FridgeProduct>> GetAllFridgeProductsAsync(bool trackChanges);

        Task<FridgeProduct> GetFridgeProductAsync(Guid fridgeProductId, bool trackChanges);

        void CreateFridgeProduct(FridgeProduct fridgeProduct);

        Task<IEnumerable<FridgeProduct>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

        void DeleteFridgeProduct(FridgeProduct fridgeProduct);
    }
}
