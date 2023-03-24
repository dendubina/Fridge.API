using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FridgesService.Contracts;
using FridgesService.DTO.Fridges;
using FridgesService.DTO.Request;
using FridgesService.EF;
using FridgesService.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace FridgesService.Services
{
    public class FridgeRepository : RepositoryBase<Fridge>, IFridgeRepository
    {
        public FridgeRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Fridge>> GetAllFridgesAsync(FridgeRequestParameters parameters, bool trackChanges)
        {
            var query = FindAll(trackChanges);

            if (parameters.OwnerEmailConfirmed)
            {
                query = query.Where(x => x.Owner.EmailConfirmed);
            }

            if (parameters.OwnerMailingConfirmed)
            {
                query = query.Where(x => x.Owner.MailingConfirmed);
            }

            if (!string.IsNullOrWhiteSpace(parameters.OwnerEmail))
            {
                query = query.Where(x => x.Owner.Email == parameters.OwnerEmail);
            }

            return await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .Include(x => x.Owner)
                .Include(x => x.FridgeModel)
                .Include(x => x.Products)
                .ThenInclude(x => x.Product)
                .ToListAsync();
        }

        public async Task<Fridge> GetFridgeAsync(Guid fridgeId, bool trackChanges)
            => await FindByCondition(x => x.Id.Equals(fridgeId), trackChanges)
                    .Include(x => x.FridgeModel)
                    .Include(x => x.Products)
                    .ThenInclude(x => x.Product)
                    .FirstOrDefaultAsync();

        public async Task<IEnumerable<Fridge>> GetByConditionAsync(Expression<Func<Fridge, bool>> expression, bool trackChanges)
            => await FindByCondition(expression, trackChanges)
                    .Include(x => x.FridgeModel)
                    .Include(x => x.Products)
                    .ThenInclude(x => x.Product)
                    .ToListAsync();

        public async Task<IEnumerable<FridgeLeaderBoardDto>> GetLeaderBoardAsync(int fridgesCount)
            => await FindAll(trackChanges: false)
                .OrderByDescending(x => x.Products.Sum(y => y.Quantity))
                .Take(fridgesCount)
                .Select(x => new FridgeLeaderBoardDto()
                {
                    FridgeName = x.Name,
                    OwnerName = x.Owner.UserName,
                    ProductsCount = x.Products.Sum(y => y.Quantity),
                })
                .ToListAsync();

        public void CreateFridge(Fridge fridge)
        {
            var fridgeModel = 
                    FindByCondition(x => x.FridgeModel.Name == fridge.Name && x.FridgeModel.Year == fridge.FridgeModel.Year, false)
                    .Select(x => x.FridgeModel)
                    .FirstOrDefault();

            if (fridgeModel is not null)
            {
                fridge.FridgeModelId = fridgeModel.Id;
            }

            Create(fridge);
        }

        public void DeleteFridge(Fridge fridge)
            => Delete(fridge);
    }
}
