using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Get the connection string from the appsettings into a class
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection")));

// Add controller support
builder.Services.AddControllers();

// Register the concrete implementation of the API Repo Interface
//builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
builder.Services.AddScoped<ICommandAPIRepo, SQLCommandAPIRepo>();

var app = builder.Build();



// Register support for controller routes
app.MapControllers();


app.MapGet("/", () => "Hello World!");

app.Run();
