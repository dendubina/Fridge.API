using System;
using System.Threading.Tasks;
using FridgeManager.AuthMicroService.EF.Constants;
using FridgeManager.AuthMicroService.Models;
using FridgeManager.AuthMicroService.Models.DTO;
using FridgeManager.AuthMicroService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.AuthMicroService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize(Roles = nameof(RoleNames.Admin))]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _userService.GetAllAsync());

        [HttpPatch]
        [Route("{userId:guid}/[action]")]
        public async Task<IActionResult> Block(Guid userId)
        {
            var user = await _userService.FindByIdAsync(userId);

            if (user is null)
            {
                return NotFound();
            }

            await _userService.BlockUserAsync(userId);

            return NoContent();
        }

        [HttpPatch]
        [Route("{userId:guid}/[action]")]
        public async Task<IActionResult> UnBlock(Guid userId)
        {
            var user = await _userService.FindByIdAsync(userId);

            if (user is null)
            {
                return NotFound();
            }

            await _userService.UnblockUserAsync(userId);

            return NoContent();
        }

        [HttpPatch]
        [Route("{userId:guid}")]
        public async Task<IActionResult> Update(Guid userId, UserToUpdate model)
        {
            var user = await _userService.FindByIdAsync(userId);

            if (user is null)
            {
                return NotFound();
            }

            await _userService.UpdateUserAsync(model);

            return NoContent();
        }
    }
}
