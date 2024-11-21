using MathComparison.src.Application.Services;
using MathComparison.src.Domain.Interfaces;
using MathComparison.src.Infrastructure.Services;

var builder = WebApplication.CreateSlimBuilder(args);
//builder.Services.AddScoped<MathExpressionGenerator>();
//builder.Services.AddScoped<MathComparisonService>();
builder.Services.AddScoped<IMathExpressionService, MathExpressionGenerator>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
 
app.UseRouting();
app.MapControllers();

app.Run();

 