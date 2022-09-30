using System.Threading.Tasks;
using AutoMapper;
using FridgeManager.FridgesMicroService.Contracts;
using FridgeManager.FridgesMicroService.EF.Entities;
using FridgeManager.Shared.Models;
using FridgeManager.Shared.Models.Constants;
using MassTransit;

namespace FridgeManager.FridgesMicroService.Services.Consumers
{
    public class ProductConsumer : IConsumer<SharedProduct>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public ProductConsumer(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
                    var entity = await _repository.Products.GetProductAsync(product.Id, trackChanges: true);
                    _mapper.Map(context.Message, entity);
                    break;

                default:
                    return;
            }

            await _repository.SaveAsync();
        }
    }
}
