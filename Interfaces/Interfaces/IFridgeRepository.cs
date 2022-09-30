using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IFridgeRepository
    {
        Task<IEnumerable<Fridge.Shared.Entities.Fridge>> GetAllFridgesAsync(bool trackChanges);

        Task<Fridge.Shared.Entities.Fridge> GetFridgeAsync(Guid fridgeId, bool trackChanges);

        void CreateFridge(Fridge.Shared.Entities.Fridge fridge);

        void DeleteFridge(Fridge.Shared.Entities.Fridge fridge);
    }
}
