using SaM.Database.Core;
using SaM.Modules.Exams.Application;
using SaM.Modules.Exams.Infra;
using SaM.Modules.Exams.Web;
using SaM.Modules.Grades.Application;
using SaM.Modules.Grades.Infra;
using SaM.Modules.Grades.Web;
using SaM.Modules.Students.Application;
using SaM.Modules.Students.Infra;
using SaM.Modules.Students.Web;
using SaM.Modules.Teachers.Application;
using SaM.Modules.Teachers.Infra;
using SaM.Modules.Teachers.Web;
using SaM.Modules.Users.Application;
using SaM.Modules.Users.Infra;
using SaM.Modules.Users.Web;

namespace SaM.Start;

public static class RegisterServices
{
    public static void Register(WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Services
            .RegisterEntityFramework();
            
        webApplicationBuilder.Services
            .RegisterUsersWeb()
            .RegisterUsersApplication()
            .RegisterUsersInfra();
        
        webApplicationBuilder.Services
            .RegisterStudentsWeb()
            .RegisterStudentsApplication()
            .RegisterStudentsInfra();

        webApplicationBuilder.Services
            .RegisterExamsWeb()
            .RegisterExamsApplication()
            .RegisterExamsInfra();
        
        webApplicationBuilder.Services
            .RegisterTeachersWeb()
            .RegisterTeachersApplication()
            .RegisterTeachersInfra();
        
        webApplicationBuilder.Services
            .RegisterGradesWeb()
            .RegisterGradesApplication()
            .RegisterGradesInfra();
    }
}