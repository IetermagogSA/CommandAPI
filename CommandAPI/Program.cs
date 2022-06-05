using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using AutoMapper;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets("d212eeac-6163-44f6-bb8c-dc20b8d2fa3f");

// Get the connection string from the appsettings into a class
ConfigurationManager configuration = builder.Configuration;

configuration.AddJsonFile("Secrets.json", optional: true);

var connectionBuilder = new NpgsqlConnectionStringBuilder();
connectionBuilder.ConnectionString = configuration.GetConnectionString("PostgreSqlConnection");
connectionBuilder.Username =  configuration["UserID"];
connectionBuilder.Password = configuration["Password"];

builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(connectionBuilder.ConnectionString));
//builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection")));

// Add controller support
builder.Services.AddControllers();

// Register the concrete implementation of the API Repo Interface
//builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
builder.Services.AddScoped<ICommandAPIRepo, SQLCommandAPIRepo>();

// Add support for mapping models to dto 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add support for the patch command
builder.Services.AddControllers().AddNewtonsoftJson(s =>
{ 
    s.SerializerSettings.ContractResolver = new
    CamelCasePropertyNamesContractResolver();
});

var app = builder.Build();





// Register support for controller routes
app.MapControllers();


app.MapGet("/", () => "Hello World!");

app.Run();
