using Contracts;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class ProductsRepository : RepositoryBase<Products>, IProductsRepository
    {
        public ProductsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
