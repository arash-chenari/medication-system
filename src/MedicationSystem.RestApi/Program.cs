using System.Configuration;
using System.Net.Mime;
using MedicationSystem.Application.Abstractions;
using MedicationSystem.Application.Abstractions.Medications;
using MedicationSystem.Application.Medications.Commands;
using MedicationSystem.Domain.Abstractions;
using MedicationSystem.Persistence.EF;
using MedicationSystem.Persistence.EF.Medications;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();
var connectionString = configuration.GetValue<string>("ConnectionString");
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<EFWriteDbContext>(_ =>
    _.UseSqlServer(connectionString));
builder.Services.AddDbContext<EFReadDbContext>(_ =>
        _.UseSqlServer(connectionString)
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddMediatR(_ =>
    _.RegisterServicesFromAssemblies(typeof(CreateMedicationCommand).Assembly));

builder.Services.AddScoped<IMedicationWriteRepository, EFMedicationWriteRepository>();
builder.Services.AddScoped<IMedicationReadRepository, EFMedicationReadRepository>();

builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(_ => _.Run( async context => 
{
    var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;
    var errorType = exception?.GetType().Name.Replace("Exception", String.Empty);
    var errorDescription = app.Environment.IsProduction() ? null : exception?.ToString();
    var result = new
    {
        Error = errorType,
        Description = errorDescription
    };

    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    context.Response.ContentType = MediaTypeNames.Application.Json;
    await context.Response.WriteAsJsonAsync(result);
}));

app.MapControllers();
app.Run();
