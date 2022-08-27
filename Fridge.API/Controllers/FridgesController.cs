using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Interfaces;
using Entities.DTO.Fridges;
using Microsoft.AspNetCore.Mvc;

namespace zFridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgesController : ControllerBase
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public FridgesController(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            var entity = _mapper.Map<Entities.Models.Fridge>(model);

             _repository.Fridges.CreateFridge(entity);
            await _repository.SaveAsync();

            var fridgeToReturn = _mapper.Map<FridgeForReturnDto>(entity);

            return CreatedAtRoute("FridgeById", new { id = fridgeToReturn.Id }, fridgeToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFridge(Guid id)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(id, trackChanges: false);

            if (fridge is null)
            {
                return NotFound();
            }

            _repository.Fridges.DeleteFridge(fridge);
            await _repository.SaveAsync();

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
