using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Exams;
using SaM.Core.SharedKernel.Entities.Grades;
using SaM.Core.SharedKernel.Entities.Students;
using SaM.Core.SharedKernel.ViewModels.Exams;
using SaM.Core.SharedKernel.ViewModels.Grades;
using SaM.Core.SharedKernel.ViewModels.Students;

namespace SaM.Modules.Grades.Web.Factories;

public class GradeViewModelFactory(
    Mapper<Student, StudentViewModel> studentViewModelMapper,
    Mapper<Grade, GradeViewModel> gradeViewModelMapper,
    Mapper<Exam, ExamViewModel> examViewModelMapper
) : ViewModelFactory<GradeViewModel, Grade>
{
    public override GradeViewModel CreateFromEntity(Grade from)
    {
        var viewModel = gradeViewModelMapper.MapNonNullable(from);
        viewModel.Exam = examViewModelMapper.MapNullable(from.Exam);
        viewModel.Student = studentViewModelMapper.MapNullable(from.Student);

        return viewModel;
    }
}