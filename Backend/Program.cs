using Backend;
using Backend.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

// Create an instance of the Database class to handle database connections
Database database = new();


// Create an instance of the Actions class, which uses the database instance to fetch data
Actions actions = new(database);

// Define a route to fetch questions by category
app.MapGet("/api/questions/{category}", actions.GetQuestionsByCategory);



app.Run();
