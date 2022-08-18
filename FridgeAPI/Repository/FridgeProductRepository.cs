using Contracts;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class FridgeProductRepository : RepositoryBase<FridgeProduct>, IFridgeProductRepository
    {
        public FridgeProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<FridgeProduct>> GetAllFridgeProductsAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<FridgeProduct> GetFridgeProductAsync(Guid fridgeProductId, bool trackChanges) =>
            (await FindByCondition(fp => fp.Id.Equals(fridgeProductId), trackChanges)
                .SingleOrDefaultAsync())!;

        public void CreateFridgeProduct(FridgeProduct fridgeProduct) => Create(fridgeProduct);

        public async Task<IEnumerable<FridgeProduct>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(fp => ids.Contains(fp.Id), trackChanges).ToListAsync();

        public void DeleteFridgeProduct(FridgeProduct fridgeProduct) =>
            Delete(fridgeProduct);
    }
}
