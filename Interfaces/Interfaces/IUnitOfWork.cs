using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IUnitOfWork
    {
        IFridgeRepository Fridges { get; }

        IFridgeProductRepository FridgeProducts { get; }

        IProductRepository Products { get; }

        Task SaveAsync();
    }
}
