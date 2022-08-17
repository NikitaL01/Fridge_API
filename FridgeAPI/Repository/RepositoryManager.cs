using Contracts;
using Entities.Context;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;

        private IFridgeRepository _fridgeRepository = null!;

        private IFridgeModelRepository _fridgeModelRepository = null!;

        private IFridgeProductsRepository _fridgeProductsRepository = null!;

        private IProductsRepository _productsRepository = null!;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IFridgeRepository Fridge
        {
            get
            {
                if (_fridgeRepository == null)
                {
                    _fridgeRepository = new FridgeRepository(_repositoryContext);
                }

                return _fridgeRepository;
            }

        }
        public IFridgeModelRepository FridgeModel
        {
            get
            {
                if (_fridgeModelRepository == null)
                {
                    _fridgeModelRepository = new FridgeModelRepository(_repositoryContext);
                }

                return _fridgeModelRepository;
            }
        }
        public IFridgeProductsRepository FridgeProducts
        {
            get
            {
                if (_fridgeProductsRepository == null)
                {
                    _fridgeProductsRepository = new FridgeProductsRepository(_repositoryContext);
                }

                return _fridgeProductsRepository;
            }
        }
        public IProductsRepository Products
        {
            get
            {
                if (_productsRepository == null)
                {
                    _productsRepository = new ProductsRepository(_repositoryContext);
                }

                return _productsRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
