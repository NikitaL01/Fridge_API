using Contracts;

namespace FridgeAPI_Tests.MoqObjects
{
    public class RepositoryManagerMock : IRepositoryManager
    {
        private IFridgeRepository? _fridgeRepository;

        private IFridgeModelRepository? _fridgeModelRepository;

        private IFridgeProductsRepository? _fridgeProductsRepository;

        private IProductsRepository? _productsRepository;

        public IFridgeRepository Fridge
        {
            get
            {
                if (_fridgeRepository == null)
                {
                    _fridgeRepository = new FridgeRepositoryMock();
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
                    _fridgeModelRepository = new FridgeModelRepositoryMock();
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
                    //_fridgeProductsRepository = new FridgeProductsRepository(_repositoryContext);
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
                    //_productsRepository = new ProductsRepository(_repositoryContext);
                }

                return _productsRepository;
            }
        }

        public async Task SaveAsync()
        {
            return;
        }
    }
}
