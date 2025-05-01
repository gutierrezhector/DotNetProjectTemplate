using Microsoft.AspNetCore.Mvc;
using SaM.Modules.Users.Ports.InBounds.Applications;
using SaM.Modules.Users.Web.Factories;
using SaM.Modules.Users.Web.Payloads;

namespace SaM.Modules.Users.Web.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(
    IUsersApplication usersApplication,
    UserViewModelFactory userViewModelFactory
) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var user = await usersApplication.GetByIdAsync(id);

        return Ok(userViewModelFactory.CreateFromEntity(user));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] UserCreationPayload creationPayload)
    {
        var newUser = await usersApplication.CreateAsync(creationPayload);

        return Created($"users/{newUser.Id}", userViewModelFactory.CreateFromEntity(newUser));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserUpdatePayload updatePayload)
    {
        var updatedUser = await usersApplication.UpdateAsync(id, updatePayload);

        return Ok(userViewModelFactory.CreateFromEntity(updatedUser));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await usersApplication.DeleteAsync(id);

        return NoContent();
    }
}