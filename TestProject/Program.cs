using FluentValidation;
using MediatR;
using Microsoft.Azure.Cosmos;
using System.Reflection;
using TestProject.Behaviours;
using TestProject.Core.Application.Services;
using TestProject.Middleware;
using TestProject.Repository;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;


builder.Services.AddSingleton((provider) =>
{

    var databaseName = configuration["CosmosDbSettings:DatabaseName"];
    var endpointUri = configuration["CosmosDbSettings:Uri"];
    var primaryKey = configuration["CosmosDbSettings:PrimaryKey"];

    var clientOptions = new CosmosClientOptions() { ConnectionMode = ConnectionMode.Direct, ApplicationName = databaseName };
    var client = new CosmosClient(endpointUri, primaryKey, clientOptions);
    //client.CreateDatabaseIfNotExistsAsync(databaseName);
    return client;
});


builder.Services.AddControllers();
builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();
