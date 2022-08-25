using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IUnitOfWork
    {

        Task Save();
    }
}
