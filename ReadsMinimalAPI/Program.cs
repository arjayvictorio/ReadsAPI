using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadsMinimalAPI.Data;
using ReadsMinimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<APIContext>
    (opt => opt.UseInMemoryDatabase("ReadsDB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); 

APIContext _context;

app.MapGet("/Hi/{name}", (string name) => 
{
    return $"Hello {name}!";
});


app.MapGet("/GetAll", () =>
{
    var ls = new List<Book>();
    ls.Add(new()
    {
        Id = 1,
        Name = "Book 1"
    });

    ls.Add(new()
    {
        Id = 2,
        Name = "Book 2"
    });

    return ls;
});

app.MapGet("/Done/{id}", JsonResult (Book book) =>
{
    //data validation logic code here

    //_context.Add(book);

    return new JsonResult(book);
});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
