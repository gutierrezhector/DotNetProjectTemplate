using SaM.Modules.Exams.Application.Factories;
using SaM.Modules.Exams.Ports.InBounds;
using SaM.Modules.Exams.Ports.OutBounds.Models;
using SaM.Modules.Exams.Web.Abstractions;
using SaM.Modules.Exams.Web.Candidates;

namespace SaM.Modules.Exams.Application;

public class ExamsApplication(IExamsRepository repository) : IExamsApplication
{
    public async Task<List<Exam>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Exam> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<Exam> Create(ExamCandidate candidate)
    {
        var examToCreate = ExamFactory.Create(candidate);

        var newExam = await repository.CreateAsync(examToCreate);

        return newExam;
    }
}