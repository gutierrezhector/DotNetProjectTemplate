using SaM.Start;
using Microsoft.EntityFrameworkCore;
using SaM.Database.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();


// builder.Services.AddDbContext<SaMDbContext>(
//     options => options
//         .UseSqlServer(
//             "Server=MSI;Database=SaM;Trusted_Connection=True;",
//             x => x.MigrationsAssembly("SaM.Database.Migrations"))
//     );

builder.Services.AddDbContext<SaMDbContext>(
    options => options
        .UseSqlServer(
            "Server=MSI;Database=SaM;Trusted_Connection=True;")
    );

RegisterServices.Register(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

app.Run();