using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Interfaces;
using Entities.DTO.FridgeProducts;
using Entities.Models;

namespace zFridge.API.Controllers
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
            var products = await _repository.FridgeProducts.GetFridgeProducts(fridgeId, trackChanges: false);

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

            if (product is not null)
            {
                return ValidationProblem($"product with id '{model.ProductId}' exists in fridge with id '{fridgeId}' already");
            }

            var fridgeProduct = _mapper.Map<FridgeProduct>(model);

            _repository.FridgeProducts.AddProductToFridge(fridgeId, fridgeProduct);
            await _repository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{productId:guid}")]
        public async Task<IActionResult> DeleteProductFromFridge(Guid fridgeId, Guid productId)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(fridgeId, trackChanges: false);
            var entity = await _repository.FridgeProducts.GetFridgeProduct(fridgeId, productId, trackChanges: false);

            if (fridge is null || entity is null)
            {
                return NotFound();
            }

            _repository.FridgeProducts.DeleteProductFromFridge(entity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductInFridge(Guid fridgeId, [Required] [FromBody] FridgeProductForManipulationDto model)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(fridgeId, trackChanges: false);

            if (fridge is null)
            {
                return NotFound();
            }

            var entity = await _repository.FridgeProducts.GetFridgeProduct(fridgeId, model.ProductId, trackChanges: true);

            if (entity is null)
            {
                return ValidationProblem($"product with id '{model.ProductId}' doesn't exists in fridge with id '{fridgeId}'");
            }

            _mapper.Map(model, entity);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
