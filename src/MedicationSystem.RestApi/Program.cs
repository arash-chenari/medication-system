using MedicationSystem.Contracts.Interfaces;
using MedicationSystem.Persistence.EF;
using MedicationSystem.Persistence.EF.Medications;
using MedicationSystem.Services.Medications;
using MedicationSystem.Services.Medications.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var configurations = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();
var connectionString = configurations.GetValue<string>("ConnectionString");

builder.Services.AddDbContext<EFDbContext>(_ => _.UseSqlServer(connectionString));
builder.Services.AddScoped<IMedicationRepository, EFMedicationRepository>();
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<IMedicationService, MedicationAppService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
