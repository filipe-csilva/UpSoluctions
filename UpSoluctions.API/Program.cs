using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using UpSoluctions.API.Repository;
using UpSoluctions.API.Repository.Interfaces;
using UpSoluctions.Data;
using UpSoluctions.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SystemContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("AllConnection")
    //,x => x.MigrationsAssembly(Assembly.)
    ));

builder.Services.AddIdentityApiEndpoints<PessoaComAcesso>().AddEntityFrameworkStores<SystemContext>();

builder.Services.AddAuthorization();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

//builder.Services.AddTransient<TokenService>();

builder.Services.AddTransient<DAL<PessoaComAcesso>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGroup("auth").MapIdentityApi<PessoaComAcesso>().WithTags("Autorization");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

//Teste de Token
//app.MapGet("/", (TokenService service) => service.GenerateToken(new User(1,"f@f.com","123", new[] {"Studenty"})));

app.Run();
