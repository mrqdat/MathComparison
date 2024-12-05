using System.Text.Json.Serialization;

namespace MathComparison.src.Application.DTOs
{
    [JsonSerializable(typeof(ComparisionRequest))]
    public class ComparisionRequest  
    {
        public string? Expression1 { get; set; }
        public string? Expression2 { get; set; }
        public string? Operator { get; set; }
    }
}
