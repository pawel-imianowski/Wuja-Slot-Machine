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

int[] possibleRolls = Enumerable.Range(0, 8).ToArray();

app.MapGet("/spin/{cost}", (decimal cost) =>
{
    // TODO: subtract cost value here, abort if cost exceeds available funds

    int[,] tileMatrix = new int[4,2];
        
    for(int i = 0; i < tileMatrix.GetLength(0); i++) // iterate columns
    {
        for(int j = 0; j < tileMatrix.GetLength(1); j++) // iterate rows
            tileMatrix[i,j] = possibleRolls[Random.Shared.Next(possibleRolls.Count())]; 
    }

    // TODO: bonus/wild logic here

    decimal reward = 0; // TODO: reward logic here - calculate reward according to drawn tiles, bonuses and cost parameter

    return new SpinOutcome
    (
        tileMatrix,
        reward
    // TODO: send info about bonuses to display animations
    );
})
.WithName("GetSpinOutcome").AllowAnonymous();

app.Run();

internal record SpinOutcome(int[,] tileMatrix, decimal reward/*, IEnumerable bonusList*/)
{
}