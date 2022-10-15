using System.Threading.Tasks;
using AutoMapper;
using FridgeManager.FridgesMicroService.Contracts;
using FridgeManager.FridgesMicroService.EF.Entities;
using FridgeManager.Shared.Models;
using FridgeManager.Shared.Models.Constants;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FridgeManager.FridgesMicroService.Services.Consumers
{
    public class ProductConsumer : IConsumer<SharedProduct>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductConsumer> _logger;

        public ProductConsumer(IUnitOfWork repository, IMapper mapper, ILogger<ProductConsumer> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<SharedProduct> context)
        {
            var product = _mapper.Map<Product>(context.Message);

            switch (context.Message.ActionType)
            {
                case ActionType.Create:
                    _repository.Products.CreateProduct(product);
                    break;

                case ActionType.Delete:
                    _repository.Products.DeleteProduct(product);
                    break;

                case ActionType.Update:
                    _repository.Products.UpdateProduct(product);
                    break;

                default:
                    return;
            }

            await _repository.SaveAsync();
            _logger.LogInformation("Product with id {Id} has been consumed. Action: {action}", product.Id, context.Message.ActionType);
        }
    }
}
