var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

// Register support for Controllers and Routes
builder.Services.AddControllers();
app.MapControllers();
