using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Interfaces;
using Entities.DTO.Products;
using Entities.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zFridge.API.Extensions;

namespace zFridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductForManipulationDto> _productForCreateValidator;
        private readonly IImageService _imageService;

        public ProductsController(IUnitOfWork repository, IMapper mapper, IValidator<ProductForManipulationDto> productForCreateValidator, IImageService imageService)
        {
            _repository = repository;
            _mapper = mapper;
            _productForCreateValidator = productForCreateValidator;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var entities = await _repository.Products.GetAllProductsAsync(trackChanges: false);

            return Ok(_mapper.Map<IEnumerable<ProductForReturnDto>>(entities));
        }

        [HttpGet("{id:guid}", Name = "ProductById")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var entity = await _repository.Products.GetProductAsync(id, trackChanges: false);

            if (entity is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductForReturnDto>(entity));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm][Required] ProductForManipulationDto model)
        {
            var result = await _productForCreateValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }

            var entity = _mapper.Map<Product>(model);

            if (model.Image is not null)
            {
                entity.ImageSource = await _imageService.AddImageReturnPath(model.Image);
            }

            _repository.Products.CreateProduct(entity);
            await _repository.SaveAsync();

            var productToReturn = _mapper.Map<ProductForReturnDto>(entity);

            return CreatedAtRoute("ProductById", new { id = productToReturn.Id }, productToReturn);

        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteProduct(Guid id) 
        {
            var entity = await _repository.Products.GetProductAsync(id, trackChanges: false);

            if (entity is not null)
            {
                _repository.Products.DeleteProduct(entity);
                await _repository.SaveAsync();
            }

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromForm][Required] ProductForManipulationDto model)
        {
            var entity = await _repository.Products.GetProductAsync(id, trackChanges: true);

            if (entity is null)
            {
                return NotFound();
            }

            var result = await _productForCreateValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }

            if (model.Image is not null)
            {
                entity.ImageSource = await _imageService.AddImageReturnPath(model.Image);
            }

            _mapper.Map(model, entity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpGet("[action]")]
        public IActionResult ChangeZeroQuantity()
        {
            _repository.FridgeProducts.ChangeZeroQuantity();

            return Ok();
        }
    }
}
