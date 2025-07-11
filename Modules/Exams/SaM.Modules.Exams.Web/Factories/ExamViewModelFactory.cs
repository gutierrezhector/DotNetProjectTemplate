using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Exams;
using SaM.Core.Types.Entities.Grades;
using SaM.Core.Types.Entities.Teachers;
using SaM.Core.Types.ViewModels.Exams;
using SaM.Core.Types.ViewModels.Grades;
using SaM.Core.Types.ViewModels.Teachers;

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