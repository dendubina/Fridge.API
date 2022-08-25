using Contracts.Interfaces;
using Entities.EF;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly AppDbContext _context;

        private IFridgeRepository _fridgeRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IFridgeRepository Fridge
        {
            get
            {
                if (_fridgeRepository == null)
                    _fridgeRepository = new FridgeRepository(_context);
                return _fridgeRepository;
            }
        }

        public async Task Save() => await _context.SaveChangesAsync();

    }
}
