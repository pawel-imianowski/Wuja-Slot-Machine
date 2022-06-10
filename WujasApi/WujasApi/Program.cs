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

app.MapGet("/spin/{cost}", (decimal cost) =>
{
    // TODO: subtract cost value here, abort if cost exceeds available funds

    string[,] tileMatrix = new string[4,2];
        
    for(int i = 0; i < tileMatrix.GetLength(0); i++) // iterate columns
    {
        for(int j = 0; j < tileMatrix.GetLength(1); j++) // iterate rows
            tileMatrix[i,j] = symbols[Random.Shared.Next(symbols.Length)]; 
    }

    // TODO: bonus/wild logic here

    decimal reward = 0; // TODO: reward logic here - calculate reward according to drawn tiles, bonuses and cost parameter

    return new SpinOutcome
    (
        tileMatrix,
        reward
        // TODO: send info about bonuses to display animations
    ).ToArray();
})
.WithName("GetSpinOutcome").AllowAnonymous();

app.Run();

internal record SpinOutcome(IEnumerable tileMatrix, decimal reward/*, IEnumerable bonusList*/)
{
}