using System.Threading.Tasks;

namespace FridgesService.Contracts
{
    public interface IUnitOfWork
    {
        IFridgeRepository Fridges { get; }

        IFridgeProductRepository FridgeProducts { get; }

        IProductRepository Products { get; }

        Task SaveAsync();
    }
}
