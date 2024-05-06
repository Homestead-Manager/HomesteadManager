using HomesteadManagerApi.Data;
using HomesteadManagerApi.Interfaces;
using HomesteadManagerApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HomesteadContext>(opt =>
	opt.UseInMemoryDatabase("Homestead"));

builder.Services.AddDbContext<PlantContext>(opt =>
	opt.UseInMemoryDatabase("Plant"));

builder.Services.AddScoped<IOpenAIService, OpenAIService>();

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
app.UseCors(policy =>
	policy.WithOrigins("http://localhost:5204")
	.AllowAnyMethod()
	.WithHeaders(HeaderNames.ContentType));
app.MapControllers();

app.Run();

