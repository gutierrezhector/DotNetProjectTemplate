using Microsoft.AspNetCore.Mvc;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Users.Ports.OutBounds.Models;
using SaM.Modules.Users.Web.Abstractions;
using SaM.Modules.Users.Web.Payloads;
using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Users.Web.Controllers;

public class UsersController(
    IUsersApplication usersApplication,
    Mapper<User, UserViewModel> userViewModelMapper
    ) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await usersApplication.GetByIdAsync(id);

        return Ok(userViewModelMapper.Map(user));
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserPayload payload)
    {
        var newUser = await usersApplication.CreateAsync(payload.ToCandidate());

        return Created($"users/{newUser.Id}", newUser);
    }
}