using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Interfaces;
using Entities.DTO.Products;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace zFridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
        public async Task<IActionResult> CreateProduct([FromBody][Required] ProductForCreateDto model)
        {
            var entity = _mapper.Map<Product>(model);

            _repository.Products.CreateProduct(entity);
            await _repository.SaveAsync();

            var productToReturn = _mapper.Map<ProductForReturnDto>(entity);

            return CreatedAtRoute("ProductById", new { id = productToReturn.Id }, productToReturn);

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id) 
        {
            var entity = await _repository.Products.GetProductAsync(id, trackChanges: false);

            if (entity is null)
            {
                return NotFound();
            }

            _repository.Products.DeleteProduct(entity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody][Required] ProductForUpdateDto model)
        {
            var entity = await _repository.Products.GetProductAsync(id, trackChanges: true);

            if (entity is null)
            {
                return NotFound();
            }

            _mapper.Map(model, entity);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
