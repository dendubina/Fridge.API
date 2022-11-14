using System.Threading.Tasks;
using FridgeManager.FridgesMicroService.Contracts;
using FridgeManager.FridgesMicroService.EF;

namespace FridgeManager.FridgesMicroService.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private IFridgeRepository _fridgeRepository;
        private IFridgeProductRepository _fridgeProductRepository;
        private IProductRepository _productRepository;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IFridgeRepository Fridges
        {
            get
            {
                if (_fridgeRepository == null)
                {
                    _fridgeRepository = new FridgeRepository(_context);
                }
                    
                return _fridgeRepository;
            }
        }

        public IFridgeProductRepository FridgeProducts
        {
            get
            {
                if (_fridgeProductRepository == null)
                {
                    _fridgeProductRepository = new FridgeProductRepository(_context);
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
                    _productRepository = new ProductRepository(_context);
                }
                   
                return _productRepository;
            }
        }

        public Task SaveAsync()
            => _context.SaveChangesAsync();
    }
}
