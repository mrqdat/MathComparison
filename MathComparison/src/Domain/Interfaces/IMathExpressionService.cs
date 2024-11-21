using MathComparison.src.Application.DTOs;

namespace MathComparison.src.Domain.Interfaces
{
    public interface IMathExpressionService
    {
        (string Expression1, string Expression2) GenerateExpressions(string difficulty);
        bool EvaluateComparison(ComparisionRequest request);
    }
}
