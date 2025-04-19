using SaM.Modules.Grades.Application.Factories;
using SaM.Modules.Grades.Application.Ports.InBounds;
using SaM.Modules.Grades.Ports.OutBounds.Models;
using SaM.Modules.Grades.Web.Abstractions;
using SaM.Modules.Grades.Web.Candidates;

namespace SaM.Modules.Grades.Application;

public class GradesApplication(
    IGradesRepository gradesRepository
) : IGradesApplication
{
    public async Task<Grade> GetByIdAsync(int id)
    {
        return await gradesRepository.GetByIdAsync(id);
    }

    public Task<Grade> CreateAsync(GradeCandidate candidate)
    {
        var gradeToCreate = GradesFactory.Create(candidate);
        var newGrade = gradesRepository.CreateAsync(gradeToCreate);

        return newGrade;
    }
}