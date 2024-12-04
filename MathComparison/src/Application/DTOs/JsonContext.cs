using System.Text.Json;
using System.Text.Json.Serialization;

namespace MathComparison.src.Application.DTOs
{
     
    [JsonSerializable(typeof(GenerateExpressionResponse))]
    public partial class JsonContext : JsonSerializerContext
    {
    }
}
