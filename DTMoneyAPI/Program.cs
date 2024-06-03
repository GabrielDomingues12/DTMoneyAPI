using Microsoft.EntityFrameworkCore;
using DTMoneyAPI.Models;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DtMoneyContext>(opt =>
    opt.UseInMemoryDatabase("DtMoney"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Middleware para logar o corpo da requisição
app.Use(async (context, next) =>
{
    context.Request.EnableBuffering();
    using (var reader = new StreamReader(context.Request.Body, leaveOpen: true))
    {
        var body = await reader.ReadToEndAsync();
        context.Request.Body.Position = 0;
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogInformation($"Request Body: {body}");
    }
    await next.Invoke();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
