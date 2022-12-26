using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FridgeManager.FridgesMicroService.Contracts;
using FridgeManager.FridgesMicroService.DTO.FridgeProducts;
using FridgeManager.FridgesMicroService.DTO.Fridges;
using FridgeManager.FridgesMicroService.DTO.Request;
using FridgeManager.FridgesMicroService.EF.Entities;
using FridgeManager.FridgesMicroService.Extensions;
using FridgeManager.FridgesMicroService.Services.Options;
using FridgeManager.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace FridgeManager.FridgesMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgesController : ControllerBase
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly IDatabase _redis;
        private readonly RedisOptions _redisOptions;

        public FridgesController(IUnitOfWork repository, IMapper mapper, IConnectionMultiplexer muxer, IOptions<RedisOptions> redisOpts)
        {
            _repository = repository;
            _mapper = mapper;
            _redis = muxer.GetDatabase();
            _redisOptions = redisOpts.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetFridges([FromQuery] FridgeRequestParameters parameters)
        {
            var fridges = await _repository.Fridges.GetAllFridgesAsync(parameters, trackChanges: false);

            return Ok(_mapper.Map<IEnumerable<FridgeForReturnDto>>(fridges));
        }

        [HttpGet("{id:guid}", Name = "FridgeById")]
        public async Task<IActionResult> GetFridge(Guid id)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(id, trackChanges: false);

            if (fridge is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FridgeForReturnDto>(fridge));
        }

        [HttpGet("leaderboard")]
        public async Task<IActionResult> GetLeaderBoard([FromQuery][Range(1, int.MaxValue)] int fridgesCount = 10)
        {
            var cachedFridges = await _redis.GetCachedListFromJsonAsync<FridgeLeaderBoardDto>(_redisOptions.LeaderBoardKey);

            if (cachedFridges.Count() <= fridgesCount)
            {
                return Ok(cachedFridges.Take(fridgesCount));
            }

            var fridges = await _repository.Fridges.GetLeaderBoardAsync(fridgesCount);

            await _redis.SetListToJsonStringAsync(_redisOptions.LeaderBoardKey, _redisOptions.LeaderBoardExpire, fridges);

            return Ok(fridges);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateFridge([FromBody][Required] FridgeForCreateDto model)
        {
            var notFoundProducts = await FindProductsThatDoesntExist(model.FridgeProducts);

            if (notFoundProducts.Any())
            {
                var message = string.Join(", ", notFoundProducts.Select(x => x.ToString()));
                ModelState.AddModelError(nameof(model.FridgeProducts), $"products with ids {message} not found");
                return ValidationProblem(ModelState);
            }

            var entity = _mapper.Map<Fridge>(model);
            entity.OwnerId = new Guid(User.GetUserId());

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

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("purge")]
        public async Task<IActionResult> DeleteTestFridge()
        {
            var fridges = await _repository.Fridges
                .GetByConditionAsync(x => x.Name == "TestFridge", trackChanges: false);

            if (fridges.Any())
            {
                _repository.Fridges.DeleteFridge(fridges.First());
                await _repository.SaveAsync();
            }

            return NoContent();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{id:guid}/purge")]
        public async Task<IActionResult> UpdateTestFridge(Guid fridgeId, [FromBody][Required] FridgeForUpdateDto model)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(Guid.Parse("859e4d86-bd70-49f5-6927-08dab71f5042"), trackChanges: true);

            if (fridge is not null)
            {
                _mapper.Map(model, fridge);
                await _repository.SaveAsync();
            }

            return NoContent();
        }

        private async Task<IEnumerable<Guid>> FindProductsThatDoesntExist(IEnumerable<FridgeProductForManipulationDto> fridgeProducts)
        {
            var result = new List<Guid>();

            if (fridgeProducts is not null && fridgeProducts.Any())
            {
                var productsIds = fridgeProducts.Select(x => x.ProductId).ToArray();

                var existedProducts = await _repository.Products.FindByIdsAsync(productsIds);

                var existedIds = existedProducts.Select(x => x.Id);

                result = productsIds.Except(existedIds).ToList();
            }

            return result;
        }
    }
}
