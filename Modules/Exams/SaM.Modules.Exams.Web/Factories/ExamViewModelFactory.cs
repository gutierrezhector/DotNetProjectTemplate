using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Exams;
using SaM.Core.SharedKernel.Entities.Grades;
using SaM.Core.SharedKernel.Entities.Teachers;
using SaM.Core.SharedKernel.ViewModels.Exams;
using SaM.Core.SharedKernel.ViewModels.Grades;
using SaM.Core.SharedKernel.ViewModels.Teachers;

namespace SaM.Modules.Exams.Web.Factories;

public class ExamViewModelFactory(
    Mapper<Exam, ExamViewModel>  examViewModelMapper,
    Mapper<Teacher, TeacherViewModel>  teacherViewModelMapper,
    Mapper<Grade, GradeViewModel>  gradeViewModelMapper
) : ViewModelFactory<ExamViewModel, Exam>
{

    public override ExamViewModel CreateFromEntity(Exam entity)
    {
        var examViewModel = examViewModelMapper.MapNonNullable(entity);

        examViewModel.ResponsibleTeacher = teacherViewModelMapper.MapNullable(entity.ResponsibleTeacher);
        examViewModel.Grades = gradeViewModelMapper.MapNullable(entity.Grades);

        return examViewModel;
    }
}