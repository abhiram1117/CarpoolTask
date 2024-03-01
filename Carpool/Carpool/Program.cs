using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Carpool.Data;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CarpoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarpoolContext") ?? throw new InvalidOperationException("Connection string 'CarpoolContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
       //policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        policy.WithOrigins("http://127.0.0.1:5500").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        
    });
});
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

app.UseCors();

app.UseRouting();