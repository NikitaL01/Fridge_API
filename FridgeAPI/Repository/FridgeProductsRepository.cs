using Contracts;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class FridgeProductsRepository : RepositoryBase<FridgeProducts>, IFridgeProductsRepository
    {
        public FridgeProductsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
