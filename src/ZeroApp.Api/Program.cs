using ZeroApp.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.UseRegisterHandler();

var app = builder.Build();

app.MapControllers();

app.Run();