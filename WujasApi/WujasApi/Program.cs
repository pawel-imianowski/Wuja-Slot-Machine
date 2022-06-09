var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var symbols = new[]
{
    "apple", "bow", "coat", "dinosaur", "fish", "girl", "heart", "midas", "pants"
};

app.MapGet("/spin", () =>
{
    var outcome = Enumerable.Range(1, 5).Select(index =>
        new SpinOutcome
        (
            symbols[Random.Shared.Next(symbols.Length)], 
            symbols[Random.Shared.Next(symbols.Length)], 
            symbols[Random.Shared.Next(symbols.Length)])
        )
        .ToArray();
    return outcome;
})
.WithName("GetSpinOutcome");

app.Run();

internal record SpinOutcome(string reel1, string reel2, string reel3)
{
}