using Microsoft.AspNetCore.Mvc;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Users.Domain.Entities;
using SaM.Modules.Users.Web.Abstractions;
using SaM.Modules.Users.Web.Payloads;
using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Users.Web.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(
    IUsersApplication usersApplication,
    Mapper<User, UserViewModel> userViewModelMapper
) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var user = await usersApplication.GetByIdAsync(id);

        return Ok(userViewModelMapper.Map(user));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] UserCreationPayload creationPayload)
    {
        var newUser = await usersApplication.CreateAsync(creationPayload.ToCandidate());

        return Created($"users/{newUser.Id}", userViewModelMapper.Map(newUser));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id,[FromBody] UserUpdatePayload updatePayload)
    {
        var updatedUser = await usersApplication.UpdateAsync(id, updatePayload.ToCandidate());

        return Ok(userViewModelMapper.Map(updatedUser));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await usersApplication.DeleteAsync(id);

        return NoContent();
    }
}