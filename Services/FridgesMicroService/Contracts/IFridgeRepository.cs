using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FridgesService.DTO.Fridges;
using FridgesService.DTO.Request;
using FridgesService.EF.Entities;

namespace FridgesService.Contracts
{
    public interface IFridgeRepository
    {
        Task<IEnumerable<Fridge>> GetAllFridgesAsync(FridgeRequestParameters parameters, bool trackChanges);

        Task<Fridge> GetFridgeAsync(Guid fridgeId, bool trackChanges);

        Task<IEnumerable<Fridge>> GetByConditionAsync(Expression<Func<Fridge, bool>> expression, bool trackChanges);

        Task<IEnumerable<FridgeLeaderBoardDto>> GetLeaderBoardAsync(int fridgesCount);

        void CreateFridge(Fridge fridge);

        void DeleteFridge(Fridge fridge);
    }
}
