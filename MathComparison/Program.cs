using MathComparison.src.Application.Services;
using MathComparison.src.Domain.Interfaces;
using System.Text.Json.Serialization.Metadata;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddJsonOptions( option =>
{
    option.JsonSerializerOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver();
});
builder.Services.AddSwaggerGen( a =>
{
    a.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "MathComparison API",
        Version = "v1",
        Description = "API for comparing math expressions."
    });
});
builder.Services.AddScoped<IMathExpressionService, MathComparisonService>();
var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI( c => {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "MathComparison API v1");
            c.RoutePrefix = ""; 
    });
}
app.UseRouting();
app.MapControllers();

app.Run();