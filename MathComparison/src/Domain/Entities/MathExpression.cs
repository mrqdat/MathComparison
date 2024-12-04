namespace MathComparison.src.Domain.Entities
{
    public class MathExpression(string expression, double result)
    {
        /// <summary>
        /// 
        /// </summary>
        public string? Expression { get; } = expression;
        /// <summary>
        /// 
        /// </summary>
        public double Result { get; } = result;
    }
}
