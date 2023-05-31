using Microsoft.EntityFrameworkCore;
using MultipleDbContexts.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserDbContext>(opt => opt.UseSqlite(
    "Data Source = UserDb.db"));
builder.Services.AddDbContext<CharacterDbContext>(opt => opt.UseSqlite(
    "Data Source = CharacterDb.db"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
