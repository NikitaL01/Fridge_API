using Contracts;

namespace FridgeAPI_Tests.MoqObjects
{
    public class RepositoryManagerMock : IRepositoryManager
    {
        private IFridgeRepository? _fridgeRepository;

        private IFridgeModelRepository? _fridgeModelRepository;

        private IFridgeProductRepository? _fridgeProductRepository;

        private IProductRepository? _productRepository;

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
        public IFridgeProductRepository FridgeProducts
        {
            get
            {
                if (_fridgeProductRepository == null)
                {
                    //_fridgeProductsRepository = new FridgeProductsRepository(_repositoryContext);
                }

                return _fridgeProductRepository;
            }
        }
        public IProductRepository Products
        {
            get
            {
                if (_productRepository == null)
                {
                    //_productsRepository = new ProductsRepository(_repositoryContext);
                }

                return _productRepository;
            }
        }

        public async Task SaveAsync()
        {
            return;
        }
    }
}
