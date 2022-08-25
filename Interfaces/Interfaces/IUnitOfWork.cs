using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IUnitOfWork
    {
        IFridgeRepository Fridge { get; }

        Task Save();
    }
}
