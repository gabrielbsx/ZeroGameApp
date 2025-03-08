using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using ZeroApp.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.UseRegisterHandler();
builder.Services.UseAutoRegisterHandlers();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();