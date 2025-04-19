using SaM.Modules.Exams.Application;
using SaM.Modules.Exams.Infra;
using SaM.Modules.Exams.Web;
using SaM.Modules.Students.Infra;
using SaM.Modules.Teachers.Application;
using SaM.Modules.Teachers.Infra;
using SaM.Modules.Users.Application;
using SaM.Modules.Users.Infra;
using SaM.Modules.Users.Web;

namespace SaM.Start;

public static class RegisterServices
{
    public static void Register(WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Services.RegisterUsersWeb();
        webApplicationBuilder.Services.RegisterUsersApplication();
        webApplicationBuilder.Services.RegisterUsersInfra();
        
        webApplicationBuilder.Services.RegisterStudentsInfra();

        webApplicationBuilder.Services.RegisterExamWeb();
        webApplicationBuilder.Services.RegisterExamsApplication();
        webApplicationBuilder.Services.RegisterExamsInfra();
        
        webApplicationBuilder.Services.RegisterTeachersApplication();
        webApplicationBuilder.Services.RegisterTeachersInfra();
    }
}