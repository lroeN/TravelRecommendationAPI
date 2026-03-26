using travel_recommendation_api.Common.Mapping;
using travel_recommendation_api.Features.Recommendations;
using Microsoft.EntityFrameworkCore;
using travel_recommendation_api.Data;

var builder = WebApplication.CreateBuilder(args);

// Connection String 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Controller Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

// Service
builder.Services.AddScoped<RecommendationService>();

MappingConfig.RegisterMappings();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();