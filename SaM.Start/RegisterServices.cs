using SaM.Database.Core;
using SaM.Modules.Exams.Application;
using SaM.Modules.Exams.Application.CQRS.Commands.Create;
using SaM.Modules.Exams.Domain;
using SaM.Modules.Exams.Infra;
using SaM.Modules.Exams.Web;
using SaM.Modules.Grades.Application;
using SaM.Modules.Grades.Domain;
using SaM.Modules.Grades.Infra;
using SaM.Modules.Grades.Web;
using SaM.Modules.Students.Application;
using SaM.Modules.Students.Domain;
using SaM.Modules.Students.Infra;
using SaM.Modules.Students.Web;
using SaM.Modules.Teachers.Application;
using SaM.Modules.Teachers.Domain;
using SaM.Modules.Teachers.Infra;
using SaM.Modules.Teachers.Web;
using SaM.Modules.Users.Application;
using SaM.Modules.Users.Domain;
using SaM.Modules.Users.Infra;
using SaM.Modules.Users.Web;

namespace SaM.Start;

public static class RegisterServices
{
    public static void Register(WebApplicationBuilder webApplicationBuilder)
    {
        RegisterMediatR(webApplicationBuilder);

        var connectionString = GetConnectionStringOrThrow(webApplicationBuilder);
        webApplicationBuilder.Services
            .RegisterEntityFramework(connectionString);

        webApplicationBuilder.Services
            .RegisterUsersWeb()
            .RegisterUsersApplication()
            .RegisterUsersInfra()
            .RegisterUsersDomain();

        webApplicationBuilder.Services
            .RegisterStudentsWeb()
            .RegisterStudentsApplication()
            .RegisterStudentsInfra()
            .RegisterStudentsDomain();

        webApplicationBuilder.Services
            .RegisterExamsWeb()
            .RegisterExamsApplication()
            .RegisterExamsInfra()
            .RegisterExamsDomain();

        webApplicationBuilder.Services
            .RegisterTeachersWeb()
            .RegisterTeachersApplication()
            .RegisterTeachersInfra()
            .RegisterTeachersDomain();

        webApplicationBuilder.Services
            .RegisterGradesWeb()
            .RegisterGradesApplication()
            .RegisterGradesInfra()
            .RegisterGradesDomain();
    }

    private static void RegisterMediatR(WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Services.AddMediatR(
            cfg =>
            {
                // with this call all handler and request from Exam namespace will be registered by reflection
                cfg.RegisterServicesFromAssemblyContaining<CreateExamCommand>();
            });
    }

    private static string GetConnectionStringOrThrow(WebApplicationBuilder webApplicationBuilder)
    {
        var connectionString = webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ApplicationException("connectionString is null or empty");
        }

        return connectionString;
    }
}