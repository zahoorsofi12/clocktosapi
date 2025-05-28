using ClockTos.Api.DIContainer;
using ClockTos.Application.DIContainer;
using ClockTos.Persistance.DIContainer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("clockTos", opt =>
    {
        opt.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services
    .AddApiServices()
    .AddApplicationServices()
    .AddPersistanceSevices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ CORS should come BEFORE Authorization
app.UseCors("clockTos");

app.UseAuthorization();

app.MapControllers();

app.Run();
