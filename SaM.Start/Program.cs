using SaM.Core.Middlewares;
using SaM.Start;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("Configs/appsettings.json", optional: false, reloadOnChange: true);

RegisterServices.Register(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();