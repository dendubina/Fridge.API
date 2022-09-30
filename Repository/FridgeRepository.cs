using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.EF;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class FridgeRepository : RepositoryBase<Entities.EF.Entities.Fridge>, IFridgeRepository
    {
        public FridgeRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Entities.EF.Entities.Fridge>> GetAllFridgesAsync(bool trackChanges)
        {
            return await
                FindAll(trackChanges)
               .Include(x => x.FridgeModel)
               .Include(x => x.Products)
               .ThenInclude(x => x.Product)
               .ToListAsync();
        }

        public async Task<Entities.EF.Entities.Fridge> GetFridgeAsync(Guid fridgeId, bool trackChanges)
        {
            return await
                FindByCondition(x => x.Id.Equals(fridgeId), trackChanges)
                .Include(x => x.FridgeModel)
                .Include(x => x.Products)
                .ThenInclude(x => x.Product)
                .SingleOrDefaultAsync();
        }

        public void CreateFridge(Entities.EF.Entities.Fridge fridge)
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

        public void DeleteFridge(Entities.EF.Entities.Fridge fridge) => Delete(fridge);
        
    }
}
