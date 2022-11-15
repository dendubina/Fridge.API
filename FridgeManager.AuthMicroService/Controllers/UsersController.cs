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

        [HttpGet]
        [Route("{userId:guid}")]
        public async Task<IActionResult> GetById(Guid userId)
        {
            var user = await _userService.FindByIdAsync(userId);

            return user is null ? NotFound() : Ok(user);
        }

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
