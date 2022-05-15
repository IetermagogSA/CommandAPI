using CommandAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add controller support
builder.Services.AddControllers();

// Register the concrete implementation of the API Repo Interface
builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();

var app = builder.Build();



// Register support for controller routes
app.MapControllers();


app.MapGet("/", () => "Hello World!");

app.Run();
