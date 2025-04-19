using SaM.Modules.Students.Application.Factories;
using SaM.Modules.Students.Ports.InBounds;
using SaM.Modules.Students.Ports.OutBounds.Models;
using SaM.Modules.Students.Web.Abstractions;
using SaM.Modules.Students.Web.Candidates;

namespace SaM.Modules.Students.Application;

public class StudentsApplication(IStudentsRepository studendRepository) : IStudentsApplication
{
    public async Task<List<Student>> GetAllAsync()
    {
        var students = await studendRepository.GetAllAsync();

        return students;
    }

    public Task<Student?> GetByIdAsync(int studentId)
    {
        var student = studendRepository.GetByIdAsync(studentId);

        return student;
    }

    public async Task<Student> Create(StudentCandidate candidate)
    {
        var studentToCreate = StudentFactory.Create(candidate);

        var newStudent = await studendRepository.Create(studentToCreate);

        return newStudent;
    }
}