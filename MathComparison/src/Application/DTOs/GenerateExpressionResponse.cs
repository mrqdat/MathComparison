
using System.Text.Json.Serialization;

namespace MathComparison.src.Application.DTOs
{
    [JsonSerializable(typeof(GenerateExpressionResponse))]
    public class GenerateExpressionResponse  
    {
        public string? Expression1 { get; set; }
        public string? Expression2 { get; set; }
    }
}
