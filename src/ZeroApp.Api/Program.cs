using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using ZeroApp.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.UseZeroApp();

var app = builder.Build();

app.Configure();

await app.RunAsync();