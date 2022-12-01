using System;
using System.Threading.Tasks;
using FridgeManager.AuthMicroService.EF.Constants;
using FridgeManager.AuthMicroService.Models.DTO;
using FridgeManager.AuthMicroService.Models.Request;
using FridgeManager.AuthMicroService.Services.Interfaces;
using FridgeManager.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.AuthMicroService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = nameof(RoleNames.Admin))]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]UserRequestParameters parameters)
            => Ok(await _userService.GetAllAsync(parameters));

        [HttpGet]
        [Route("{userId:guid}")]
        public async Task<IActionResult> GetById(Guid userId)
        {
            var user = await _userService.FindByIdAsync(userId);

            if (User.IsInRole(nameof(RoleNames.Admin)) || User.GetUserId() == userId.ToString())
            {
                return user is null ? NotFound() : Ok(user);
            }

            return Forbid();
        }

        [Authorize(Roles = nameof(RoleNames.Admin))]
        [HttpPatch]
        [Route("{userId:guid}/[action]")]
        public async Task<IActionResult> ChangeStatus(Guid userId, ChangeStatusModel model)
        {
            var user = await _userService.FindByIdAsync(userId);

            if (user is null)
            {
                return NotFound();
            }

            await _userService.ChangeStatusAsync(userId, Enum.Parse<UserStatus>(model.Status));

            return NoContent();
        }

        [Authorize(Roles = nameof(RoleNames.Admin))]
        [HttpPatch]
        [Route("{userId:guid}/[action]")]
        public async Task<IActionResult> AddRole(Guid userId, ChangeRoleModel model)
        {
            var user = await _userService.FindByIdAsync(userId);

            if (user is null)
            {
                return NotFound();
            }

            await _userService.AddRoleAsync(userId, Enum.Parse<RoleNames>(model.Role));

            return NoContent();
        }

        [Authorize(Roles = nameof(RoleNames.Admin))]
        [HttpPatch]
        [Route("{userId:guid}/[action]")]
        public async Task<IActionResult> RemoveRole(Guid userId, ChangeRoleModel model)
        {
            var user = await _userService.FindByIdAsync(userId);

            if (user is null)
            {
                return NotFound();
            }

            await _userService.RemoveRoleAsync(userId, Enum.Parse<RoleNames>(model.Role));

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

            if (!User.IsInRole(nameof(RoleNames.Admin)) && User.GetUserId() != userId.ToString())
            {
                return Forbid();
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
