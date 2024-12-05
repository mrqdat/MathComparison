using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;

namespace MathComparison.src.Application.DTOs
{
    [JsonSerializable(typeof(Result))]
    public class Result : SnakeCaseNamingStrategy
    {
        public bool IsValid { get; set; }
    }
}
