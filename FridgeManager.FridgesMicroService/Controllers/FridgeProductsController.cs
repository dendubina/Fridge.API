using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using FridgeManager.FridgesMicroService.Contracts;
using FridgeManager.FridgesMicroService.DTO.FridgeProducts;
using FridgeManager.FridgesMicroService.EF.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.FridgesMicroService.Controllers
{
    [Route("api/fridges/{fridgeId:guid}/products")]
    [ApiController]
    public class FridgeProductsController : ControllerBase
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public FridgeProductsController(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsInFridge(Guid fridgeId)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(fridgeId, trackChanges: false);

            if (fridge is null)
            {
                return NotFound();
            }

            var products = await _repository.FridgeProducts.GetFridgeProductsAsync(fridgeId, trackChanges: false);

            return Ok(_mapper.Map<IEnumerable<FridgeProductForReturnDto>>(products));
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToFridge(Guid fridgeId, [Required][FromBody] FridgeProductForManipulationDto model)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(fridgeId, trackChanges: false);

            if (fridge is null)
            {
                return NotFound();
            }

            var product = await _repository.Products.GetProductAsync(model.ProductId, trackChanges: false);

            if (product is null)
            {
                ModelState.AddModelError(nameof(model.ProductId), $"product with id '{model.ProductId}' doesn't exists");
                return ValidationProblem(ModelState);
            }

            var fridgeProduct = _mapper.Map<FridgeProduct>(model);

            await _repository.FridgeProducts.AddProductToFridgeAsync(fridgeId, fridgeProduct);
            await _repository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{productId:guid}")]
        public async Task<IActionResult> DeleteProductFromFridge(Guid fridgeId, Guid productId)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(fridgeId, trackChanges: false);
            var fridgeProduct = await _repository.FridgeProducts.GetFridgeProductAsync(fridgeId, productId, trackChanges: false);

            if (fridge is not null && fridgeProduct is not null)
            {
                _repository.FridgeProducts.DeleteProductFromFridge(fridgeProduct);
                await _repository.SaveAsync();
            }

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductInFridge(Guid fridgeId, [Required][FromBody] FridgeProductForManipulationDto model)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(fridgeId, trackChanges: false);

            if (fridge is null)
            {
                return NotFound();
            }

            var product = await _repository.Products.GetProductAsync(model.ProductId, trackChanges: false);

            if (product is null)
            {
                ModelState.AddModelError(nameof(model.ProductId), $"product with id '{model.ProductId}' doesn't exists");
                return ValidationProblem(ModelState);
            }

            var entity = await _repository.FridgeProducts.GetFridgeProductAsync(fridgeId, model.ProductId, trackChanges: true);

            _mapper.Map(model, entity);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
