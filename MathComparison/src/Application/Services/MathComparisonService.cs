using MathComparison.src.Domain.Entities;
using MathComparison.src.Domain.ValueObject;

namespace MathComparison.src.Application.Services
{
    public class MathComparisonService
    {
        public bool Compare(MathExpression left, MathExpression right, ComparisionOperator op)
        {
            return op switch
            {
                ComparisionOperator.LessThan => left.Result < right.Result,
                ComparisionOperator.Equal => left.Result == right.Result,
                ComparisionOperator.GreaterThan => left.Result > right.Result,
                _ => throw new InvalidOperationException("unsupported operator")
            };

        }
    }
}
