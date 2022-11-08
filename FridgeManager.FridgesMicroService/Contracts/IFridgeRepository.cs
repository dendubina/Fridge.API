using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FridgeManager.FridgesMicroService.EF.Entities;

namespace FridgeManager.FridgesMicroService.Contracts
{
    public interface IFridgeRepository
    {
        Task<IEnumerable<Fridge>> GetAllFridgesAsync(bool trackChanges);

        Task<Fridge> GetFridgeAsync(Guid fridgeId, bool trackChanges);

        Task<IEnumerable<Fridge>> GetByCondition(Expression<Func<Fridge, bool>> expression, bool trackChanges);

        void CreateFridge(Fridge fridge);

        void DeleteFridge(Fridge fridge);
    }
}
