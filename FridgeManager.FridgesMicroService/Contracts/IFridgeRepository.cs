using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FridgeManager.FridgesMicroService.DTO.Request;
using FridgeManager.FridgesMicroService.EF.Entities;

namespace FridgeManager.FridgesMicroService.Contracts
{
    public interface IFridgeRepository
    {
        Task<IEnumerable<Fridge>> GetAllFridgesAsync(FridgeRequestParameters parameters, bool trackChanges);

        Task<Fridge> GetFridgeAsync(Guid fridgeId, bool trackChanges);

        Task<IEnumerable<Fridge>> GetByConditionAsync(Expression<Func<Fridge, bool>> expression, bool trackChanges);

        void CreateFridge(Fridge fridge);

        void DeleteFridge(Fridge fridge);
    }
}
