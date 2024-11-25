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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Math compare api");
             
        c.RoutePrefix = "";
    });
}
app.UseRouting();
app.MapControllers();

app.Run();

 