using DemoAPI.IServices;
using DemoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMathService, MathService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Demo purpose: Uncomment the following line to enable Swagger only in development mode.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.MapGet("/config", (IConfiguration configuration) =>
{
    return new
    {
        DefaultConnection = configuration.GetConnectionString("DefaultConnection"),
        Version = configuration["Version"],
        Environment = configuration["Environment"]
    };
})
.WithName("config")
.WithOpenApi();

app.MapGet("/Add/{a}/{b}", (double a, double b, IMathService mathService) =>
{
    return mathService.Add(a, b);
})
.WithName("add")
.WithOpenApi();

app.MapGet("/delay", async () =>
{
    // 50ms delay to simulate a slow response
    await Task.Delay(50);

    return new
    {
        message = "Done",
        timestamp = DateTime.UtcNow
    };
})
.WithName("delay")
.WithOpenApi();

app.MapGet("/work", async () =>
{
    var watch = System.Diagnostics.Stopwatch.StartNew();

    while (watch.ElapsedMilliseconds < 100)
    {
        // Simulate work by calculating a square root of a random number
        Math.Sqrt(new Random().Next());
    }
    return new
    {
        message = "Done",
        timestamp = DateTime.UtcNow
    };
})
.WithName("work")
.WithOpenApi();

app.Run();
