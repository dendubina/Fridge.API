using System;
using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IFridgeRepository
    {
        Task<IEnumerable<Fridge>> GetAllFridgesAsync(bool trackChanges);

        Task<Fridge> GetFridgeAsync(Guid fridgeId, bool trackChanges);

        void CreateFridge(Fridge fridge);

        void DeleteFridge(Fridge fridge);
    }
}
