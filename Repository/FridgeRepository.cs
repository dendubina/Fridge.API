using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.EF;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class FridgeRepository : RepositoryBase<Fridge>, IFridgeRepository
    {
        public FridgeRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Fridge>> GetAllFridgesAsync(bool trackChanges)
        {
            return await
                FindAll(trackChanges)
               .Include(x => x.FridgeModel)
               .Include(x => x.Products)
               .ToListAsync();
        }

        public async Task<Fridge> GetFridgeAsync(Guid fridgeId, bool trackChanges)
        {
            return await
                FindByCondition(x => x.Id.Equals(fridgeId), trackChanges)
                .Include(x => x.FridgeModel)
                .Include(x => x.Products)
                .SingleOrDefaultAsync();
        }

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
