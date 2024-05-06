using HomesteadManagerApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HomesteadContext>(opt =>
    opt.UseInMemoryDatabase("Homestead"));

builder.Services.AddDbContext<PlantContext>(opt =>
    opt.UseInMemoryDatabase("Plant"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorOrigin", builder =>
    {
        builder.WithOrigins("https://localhost:7052") // Replace with the actual origin of your Blazor app
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials(); // Include this if credentials are needed, like cookies or authentication.
    });
});

var app = builder.Build();

app.UseCors("AllowBlazorOrigin"); // Use the CORS policy

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

