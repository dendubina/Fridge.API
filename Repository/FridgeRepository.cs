using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.EF;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class FridgeRepository : RepositoryBase<Fridge.Shared.Entities.Fridge>, IFridgeRepository
    {
        public FridgeRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Fridge.Shared.Entities.Fridge>> GetAllFridgesAsync(bool trackChanges)
        {
            return await
                FindAll(trackChanges)
               .Include(x => x.FridgeModel)
               .Include(x => x.Products)
               .ThenInclude(x => x.Product)
               .ToListAsync();
        }

        public async Task<Fridge.Shared.Entities.Fridge> GetFridgeAsync(Guid fridgeId, bool trackChanges)
        {
            return await
                FindByCondition(x => x.Id.Equals(fridgeId), trackChanges)
                .Include(x => x.FridgeModel)
                .Include(x => x.Products)
                .ThenInclude(x => x.Product)
                .SingleOrDefaultAsync();
        }

        public void CreateFridge(Fridge.Shared.Entities.Fridge fridge)
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

        public void DeleteFridge(Fridge.Shared.Entities.Fridge fridge) => Delete(fridge);
        
    }
}
