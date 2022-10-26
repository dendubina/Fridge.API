using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FridgeManager.FridgesMicroService.Contracts;
using FridgeManager.FridgesMicroService.EF;
using FridgeManager.FridgesMicroService.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace FridgeManager.FridgesMicroService.Services
{
    public class FridgeRepository : RepositoryBase<Fridge>, IFridgeRepository
    {
        public FridgeRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Fridge>> GetAllFridgesAsync(bool trackChanges)
            => await FindAll(trackChanges)
                    .Include(x => x.FridgeModel)
                    .Include(x => x.Products)
                    .ThenInclude(x => x.Product)
                    .ToListAsync();

        public async Task<Fridge> GetFridgeAsync(Guid fridgeId, bool trackChanges)
            => await FindByCondition(x => x.Id.Equals(fridgeId), trackChanges)
                    .Include(x => x.FridgeModel)
                    .Include(x => x.Products)
                    .ThenInclude(x => x.Product)
                    .SingleOrDefaultAsync();

        public async Task<IEnumerable<Fridge>> GetByCondition(Expression<Func<Fridge, bool>> expression, bool trackChanges)
            => await FindByCondition(expression, trackChanges)
                    .Include(x => x.FridgeModel)
                    .Include(x => x.Products)
                    .ThenInclude(x => x.Product)
                    .ToListAsync();

        public void CreateFridge(Fridge fridge)
        {
            var fridgeModel = 
                    FindByCondition(x => x.FridgeModel.Name == fridge.Name && x.FridgeModel.Year == fridge.FridgeModel.Year, false)
                    .Select(x => x.FridgeModel)
                    .FirstOrDefault();

            if (fridgeModel is not null)
            {
                fridge.FridgeModel = fridgeModel;
            }

            Create(fridge);
        }

        public void DeleteFridge(Fridge fridge) => Delete(fridge);
    }
}
