using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IFridgeRepository
    {
        Task<IEnumerable<Entities.EF.Entities.Fridge>> GetAllFridgesAsync(bool trackChanges);

        Task<Entities.EF.Entities.Fridge> GetFridgeAsync(Guid fridgeId, bool trackChanges);

        void CreateFridge(Entities.EF.Entities.Fridge fridge);

        void DeleteFridge(Entities.EF.Entities.Fridge fridge);
    }
}
