using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Contracts;
using ProductsService.EF.Entities;
using ProductsService.Models;

namespace ProductsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public ProductsController(IProductService productService, IMapper mapper, IImageService imageService)
        {
            _productService = productService;
            _mapper = mapper;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var entities = await _productService.GetAllProductsAsync();

            return Ok(_mapper.Map<IEnumerable<ProductForReturn>>(entities));
        }

        [HttpGet("{id:guid}", Name = "ProductById")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var entity = await _productService.GetProductAsync(id);

            if (entity is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductForReturn>(entity));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm][Required] ProductForManipulation model)
        {
            var entity = _mapper.Map<Product>(model);

            if (model.Image is not null)
            {
                entity.ImageSource = await _imageService.AddImageGetPath(model.Image);
            }

            await _productService.CreateProductAsync(entity);

            var productToReturn = _mapper.Map<ProductForReturn>(entity);

            return CreatedAtRoute("ProductById", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var entity = await _productService.GetProductAsync(id);

            if (entity is not null)
            {
                await _productService.DeleteProductAsync(entity);
            }

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromForm][Required] ProductForManipulation model)
        {
            var entity = await _productService.GetProductAsync(id);

            if (entity is null)
            {
                return NotFound();
            }

            if (model.Image is not null)
            {
                entity.ImageSource = await _imageService.AddImageGetPath(model.Image);
            }

            _mapper.Map(model, entity);
            await _productService.UpdateProductAsync(entity);

            return NoContent();
        }
    }
}
