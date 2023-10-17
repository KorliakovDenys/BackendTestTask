using System.Data;
using KorliakovBackendTestTask;
using KorliakovBackendTestTask.Models;
using KorliakovBackendTestTask.Repository;
using KorliakovBackendTestTask.Utils;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

var colorsArray = builder.Configuration.GetSection("Colors").Get<string[]>() ??
                  throw new InvalidOperationException("'Colors}' not found.");

var priceProbabilitiesArray = builder.Configuration.GetSection("PriceProbabilities").Get<PriceProbability[]>() ??
                              throw new InvalidOperationException("'PriceProbabilities' not found.");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddSingleton<IDbConnection>(provider => new SqlConnection(connectionString));
builder.Services.AddSingleton<IRepository<Client>, Repository<Client>>();
builder.Services.AddScoped<IExperimentHelper, ExperimentHelper>(provider =>
    new ExperimentHelper(provider.GetRequiredService<ILogger<ExperimentHelper>>(),provider.GetRequiredService<IRepository<Client>>()!,
        colorsArray,
        priceProbabilitiesArray));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();