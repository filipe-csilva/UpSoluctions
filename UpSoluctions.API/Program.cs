using Microsoft.EntityFrameworkCore;
using UpSoluctions.API.Repository;
using UpSoluctions.API.Repository.Interfaces;
using UpSoluctions.Data;
using UpSoluctions.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SystemContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("AllConnection")
    //,x => x.MigrationsAssembly(Assembly.)
    ));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<TokenService>();

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

app.MapControllers();

app.MapGet("/", (TokenService service) => service.GenerateToken(null));

app.Run();
