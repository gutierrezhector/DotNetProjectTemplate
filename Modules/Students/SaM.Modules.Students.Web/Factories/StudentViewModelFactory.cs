using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Students;
using SaM.Core.Types.Entities.Users;
using SaM.Core.Types.ViewModels.Students;
using SaM.Core.Types.ViewModels.Users;

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