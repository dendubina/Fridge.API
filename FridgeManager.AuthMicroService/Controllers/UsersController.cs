using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FridgeManager.AuthMicroService.EF.Constants;
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

        [HttpGet]
        [Route("{userId:guid}")]
        public async Task<IActionResult> GetById(Guid userId)
        {
            var user = await _userService.FindByIdAsync(userId);

            return user is null ? NotFound() : Ok(user);
        }

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
        [Route("{userId:guid}/[action]")]
        public async Task<IActionResult> AddAdmin(Guid userId)
        {
            var user = await _userService.FindByIdAsync(userId);

            if (user is null)
            {
                return NotFound();
            }

            await _userService.AddAdminAsync(userId);
            return NoContent();
        }

        [HttpPatch]
        [Route("{userId:guid}/[action]")]
        public async Task<IActionResult> RemoveAdmin(Guid userId)
        {
            var user = await _userService.FindByIdAsync(userId);

            if (user is null)
            {
                return NotFound();
            }

            await _userService.RemoveAdminAsync(userId);
            return NoContent();
        }

        [HttpPatch]
        [Route("{userId:guid}")]
        public async Task<IActionResult> Update(Guid userId, [FromBody][Required] UserToUpdate model)
        {
            var user = await _userService.FindByIdAsync(userId);

            if (user is null)
            {
                return NotFound();
            }

            try
            {
                await _userService.UpdateUserAsync(model);
                return NoContent();
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                return ValidationProblem(ModelState);
            }
        }
    }
}
