using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Interfaces;
using Entities.DTO.FridgeProducts;
using Entities.Models;
using FluentValidation;
using zFridge.API.Extensions;

namespace zFridge.API.Controllers
{
    [Route("api/fridges/{fridgeId:guid}/products")]
    [ApiController]
    public class FridgeProductsController : ControllerBase
    {
        private readonly IValidator<FridgeProductForManipulationDto> _fridgeProductValidator;

        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public FridgeProductsController(IUnitOfWork repository, IMapper mapper, IValidator<FridgeProductForManipulationDto> fridgeProductValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _fridgeProductValidator = fridgeProductValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsInFridge(Guid fridgeId)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(fridgeId, trackChanges: false);

            if (fridge is null)
            {
                return NotFound();
            }

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

            if (product is null)
            {
                ModelState.AddModelError(nameof(model.ProductId), $"product with id '{model.ProductId}' doesn't exists");
                return ValidationProblem(ModelState);
            }

            var fridgeProduct = _mapper.Map<FridgeProduct>(model);

            await _repository.FridgeProducts.AddProductToFridge(fridgeId, fridgeProduct);
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
        public async Task<IActionResult> UpdateProductInFridge(Guid fridgeId, [Required][FromBody] FridgeProductForManipulationDto model)
        {
            var result = await _fridgeProductValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }

            var fridge = await _repository.Fridges.GetFridgeAsync(fridgeId, trackChanges: false);

            if (fridge is null)
            {
                return NotFound();
            }

            var entity = await _repository.FridgeProducts.GetFridgeProduct(fridgeId, model.ProductId, trackChanges: true);

            _mapper.Map(model, entity);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
