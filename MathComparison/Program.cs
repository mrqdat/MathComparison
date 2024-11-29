using MathComparison.src.Application.Services;
using MathComparison.src.Domain.Interfaces;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddScoped<IMathExpressionService, MathComparisonService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Math compare api",
        Version = "v1",
        Description = "API for comparing math expressions."
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
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