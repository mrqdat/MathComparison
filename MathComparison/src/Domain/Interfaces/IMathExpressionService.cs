using MathComparison.src.Application.DTOs;

namespace MathComparison.src.Domain.Interfaces
{
    public interface IMathExpressionService
    {
        Task<GenerateExpressionResponse> GenerateExpressions(string difficulty);
        Task<bool> EvaluateComparison(ComparisionRequest request);
    }
}
