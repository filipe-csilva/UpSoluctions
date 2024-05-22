using Microsoft.EntityFrameworkCore;
using UpSoluctions.Data;
using UpSoluctions.Repository;
using UpSoluctions.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SystemContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("AllConnection")));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

builder.Services.AddControllers();

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

app.Run();
