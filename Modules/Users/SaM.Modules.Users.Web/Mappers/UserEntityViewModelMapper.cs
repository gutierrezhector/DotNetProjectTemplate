﻿using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Users;
using SaM.Core.Types.ViewModels.Users;

namespace SaM.Modules.Users.Web.Mappers;

public class UserEntityViewModelMapper : Mapper<User, UserViewModel>
{
    public override UserViewModel MapNonNullable(User from)
    {
        return new UserViewModel
        {
            Id = from.Id,
            FirstName = from.FirstName,
            LastName = from.LastName,
        };
    }
}