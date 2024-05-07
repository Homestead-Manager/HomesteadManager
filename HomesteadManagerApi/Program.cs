using HomesteadManagerApi.Data;
using HomesteadManagerApi.Interfaces;
using HomesteadManagerApi.Models;
using HomesteadManagerApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.Development.json",
    optional: true,
    reloadOnChange: true);

builder.Services.Configure<OpenAIConfig>(options => builder.Configuration.GetSection("OpenAIConfig").Bind(options));
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddDbContext<HomesteadContext>(opt =>
    opt.UseInMemoryDatabase("Homestead"));

builder.Services.AddDbContext<PlantContext>(opt =>
    opt.UseInMemoryDatabase("Plant"));

builder.Services.AddDbContext<GardenContext>(opt =>
    opt.UseInMemoryDatabase("Garden"));

builder.Services.AddDbContext<BedContext>(opt =>
    opt.UseInMemoryDatabase("Bed"));

builder.Services.AddHttpClient<OpenAIService>();

builder.Services.AddSingleton<IOpenAIService, OpenAIService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var blazorUrl = builder.Configuration["BlazorUrl"];
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorOrigin", builder =>
    {
        builder.WithOrigins(blazorUrl) // Replace with the actual origin of your Blazor app
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

