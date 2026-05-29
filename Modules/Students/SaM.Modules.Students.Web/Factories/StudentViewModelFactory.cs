using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Students;
using SaM.Core.SharedKernel.Entities.Users;
using SaM.Core.SharedKernel.ViewModels.Students;
using SaM.Core.SharedKernel.ViewModels.Users;

namespace SaM.Modules.Students.Web.Factories;

public class StudentViewModelFactory(
    Mapper<Student, StudentViewModel> studentViewModelMapper,
    Mapper<User, UserViewModel> userViewModelMapper
) : ViewModelFactory<StudentViewModel, Student>
{

    public override StudentViewModel CreateFromEntity(Student entity)
    {
        var viewModel = studentViewModelMapper.MapNonNullable(entity);

        viewModel.User = userViewModelMapper.MapNullable(entity.User);

        return viewModel;
    }
}