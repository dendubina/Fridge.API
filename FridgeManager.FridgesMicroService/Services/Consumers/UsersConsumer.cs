using System.Threading.Tasks;
using AutoMapper;
using FridgeManager.FridgesMicroService.EF;
using FridgeManager.FridgesMicroService.EF.Entities;
using FridgeManager.Shared.Models;
using FridgeManager.Shared.Models.Constants;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FridgeManager.FridgesMicroService.Services.Consumers
{
    public class UsersConsumer : IConsumer<SharedUser>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersConsumer> _logger;

        public UsersConsumer(AppDbContext dbContext, IMapper mapper, ILogger<UsersConsumer> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<SharedUser> context)
        {
            var owner = _mapper.Map<Owner>(context.Message);

            switch (context.Message.ActionType)
            {
                case ActionType.Create:
                    _dbContext.Owners.Add(owner);
                    break;

                case ActionType.Update:
                    _dbContext.Owners.Update(owner);
                    break;

                case ActionType.Delete:
                    _dbContext.Owners.Remove(owner);
                    break;

                default:
                    return;
            }

            await _dbContext.SaveChangesAsync();
            _logger.LogInformation("User with id {Id} has been consumed. Action: {action}", owner.Id, context.Message.ActionType);
        }
    }
}
