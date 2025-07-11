using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Teachers;
using SaM.Core.Types.Entities.Users;
using SaM.Core.Types.ViewModels.Teachers;
using SaM.Core.Types.ViewModels.Users;

namespace SaM.Modules.Teachers.Web.Factories;

public class TeacherViewModelFactory(
    Mapper<Teacher, TeacherViewModel> teacherViewModelMapper,
    Mapper<User, UserViewModel> userViewModelMapper
) : ViewModelFactory<TeacherViewModel, Teacher>
{

    public override TeacherViewModel CreateFromEntity(Teacher entity)
    {
        var viewModel = teacherViewModelMapper.MapNonNullable(entity);

        viewModel.User = userViewModelMapper.MapNullable(entity.User);

        return viewModel;
    }
}