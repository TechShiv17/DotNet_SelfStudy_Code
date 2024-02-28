using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductAPIContext") ?? throw new InvalidOperationException("Connection string 'ProductAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p=>p.AddDefaultPolicy(build =>
{
    build.WithOrigins("http://localhost:3000");
    build.AllowAnyMethod();
    build.AllowAnyHeader();
}));

builder.Services.AddCors(p => p.AddPolicy("corspolicy",build =>
{
    build.WithOrigins("*");
    build.AllowAnyHeader();
    build.AllowAnyMethod();
}));

//enable CORS for single domain

//enable CORS for multiple domain 

//enable CORS for any domain (No restrictions)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors("corspolicy");

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
