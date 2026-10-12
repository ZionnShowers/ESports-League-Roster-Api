using Microsoft.EntityFrameworkCore;
using ESports_League_Roster_Api.Repositories;
// using ESports_League_Roster_Api.Dtos;
// using ESports_League_Roster_Api.Models;
using ESports_League_Roster_Api.Services;
using ESports_League_Roster_Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPlayerServices, PlayerServices>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
