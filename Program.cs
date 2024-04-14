using memory_words.Data.Implementations;
using memory_words.Data.Interfaces;
using memory_words.Models;
using memory_words.Services.Implementations;
using memory_words.Services.Interfaces;
using memory_words_api.Data.Implementations;
using memory_words_api.Data.Interfaces;
using memory_words_api.Services.Implementations;
using memory_words_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Entity Framework
builder.Services.AddDbContext<MemoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});

//Services
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ISectionService, SectionService>();

//Repositories
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();

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
