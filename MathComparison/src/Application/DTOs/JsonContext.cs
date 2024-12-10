using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MathComparison.src.Application.DTOs
{
    [JsonSerializable(typeof(MathResult))]
    [JsonSerializable(typeof(GenerateExpressionResponse))]
    [JsonSerializable(typeof(ComparisionRequest))]
    public partial class JsonContext : JsonSerializerContext
    {
    }
}
