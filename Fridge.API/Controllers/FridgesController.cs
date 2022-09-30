using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Interfaces;
using Entities.DTO.Fridges;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Fridge.API.Extensions;

namespace Fridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgesController : ControllerBase
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<FridgeForCreateDto> _createFridgeValidator;

        public FridgesController(IUnitOfWork repository, IMapper mapper, IValidator<FridgeForCreateDto> createFridgeValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _createFridgeValidator = createFridgeValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFridges()
        {
            var fridges = await _repository.Fridges.GetAllFridgesAsync(trackChanges: false);

            return Ok(_mapper.Map<IEnumerable<FridgeForReturnDto>>(fridges));
        }

        [HttpGet("{id:guid}", Name = "FridgeById")]
        public async Task<IActionResult> GetFridge(Guid id)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(id, trackChanges: false);

            if (fridge == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FridgeForReturnDto>(fridge));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFridge([FromBody][Required] FridgeForCreateDto model)
        {
            var result = await _createFridgeValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }

            var entity = _mapper.Map<Shared.Entities.Fridge>(model);

             _repository.Fridges.CreateFridge(entity);
            await _repository.SaveAsync();

            var fridgeToReturn = _mapper.Map<FridgeForReturnDto>(entity);

            return CreatedAtRoute("FridgeById", new { id = fridgeToReturn.Id }, fridgeToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFridge(Guid id)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(id, trackChanges: false);

            if (fridge is not null)
            {
                _repository.Fridges.DeleteFridge(fridge);
                await _repository.SaveAsync();
            }

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateFridge(Guid id, [FromBody][Required] FridgeForUpdateDto model)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(id, trackChanges: true);

            if (fridge is null)
            {
                return NotFound();
            }

            _mapper.Map(model, fridge);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
