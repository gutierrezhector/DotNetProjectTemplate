using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Exams.Ports.OutBounds.Models;
using SaM.Modules.Exams.Web.Dtos;

namespace SaM.Modules.Exams.Web.Mappers;

public class ExamMapper : Mapper<Exam, ExamDto>
{
    public override ExamDto Map(Exam exam)
    {
        return new ExamDto
        {
            Title = exam.Title,
            StartDate = exam.StartDate,
            EndDate = exam.EndDate
        };
    }
}