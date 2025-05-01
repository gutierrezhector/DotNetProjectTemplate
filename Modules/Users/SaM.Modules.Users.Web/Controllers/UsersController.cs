using Microsoft.AspNetCore.Mvc;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Users;
using SaM.Modules.Users.Ports.InBounds.Applications;
using SaM.Modules.Users.Web.Payloads;
using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Users.Web.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(
    IUsersApplication usersApplication,
    Mapper<User, UserViewModel> userEntityViewModelMapper
) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var user = await usersApplication.GetByIdAsync(id);

        return Ok(userEntityViewModelMapper.MapNonNullable(user));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] UserCreationPayload creationPayload)
    {
        var newUser = await usersApplication.CreateAsync(creationPayload);

        return Created($"users/{newUser.Id}", userEntityViewModelMapper.MapNonNullable(newUser));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserUpdatePayload updatePayload)
    {
        var updatedUser = await usersApplication.UpdateAsync(id, updatePayload);

        return Ok(userEntityViewModelMapper.MapNonNullable(updatedUser));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await usersApplication.DeleteAsync(id);

        return NoContent();
    }
}