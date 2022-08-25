using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Interfaces;
using Entities.DTO.Fridge;
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
            var fridges = await _repository.Fridge.GetAllFridgesAsync(trackChanges: false);

            return Ok(_mapper.Map<IEnumerable<FridgeDto>>(fridges));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetFridge(Guid id)
        {
            var fridge = await _repository.Fridge.GetFridgeAsync(id, trackChanges: false);

            if (fridge == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FridgeDto>(fridge));
        }
    }
}
