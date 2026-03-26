using BackendCSharp.Services;
using BackendCSharp.Models;
using BackendCSharp.DTOs;
using BackendCSharp.Validators;
using BackendCSharp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<IPeopleService, PeopleService>();
//builder.Services.AddSingleton<IPeopleService, People2Service>();
builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("peopleService");
builder.Services.AddKeyedSingleton<IPeopleService, People2Service>("people2Service");

builder.Services.AddKeyedSingleton<IRandomService, RandomService>("randomSingleton");
builder.Services.AddKeyedScoped<IRandomService, RandomService>("randomScoped");
builder.Services.AddKeyedTransient<IRandomService, RandomService>("randomTransient");

builder.Services.AddScoped<IPostService, PostService>();
//builder.Services.AddScoped<IBeerService, BeerService>();
builder.Services.AddKeyedScoped<ICommonService<BeerDTO, BeerInsertDTO, BeerUpdateDTO>, BeerService>("beerService");

// Configurar Uri
builder.Services.AddHttpClient<IPostService, PostService>( c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);
    
});

// Repository
builder.Services.AddScoped<IRepository<Beer>, BeerRepository>();



// EntityFramework -  Configurar base de datos
builder.Services.AddDbContext<StoreContext>( options =>
{ 
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});

// Validadores
builder.Services.AddScoped<IValidator<BeerInsertDTO>, BeerInsertValidator>();
builder.Services.AddScoped<IValidator<BeerUpdateDTO>, BeerUpdateValidator>();



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

app.Run();

