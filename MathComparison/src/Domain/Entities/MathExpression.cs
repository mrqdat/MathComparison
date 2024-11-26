namespace MathComparison.src.Domain.Entities
{
    public class MathExpression
    {
        /// <summary>
        /// 
        /// </summary>
        public string? Expression { get;  }
        /// <summary>
        /// 
        /// </summary>
        public double Result { get;  }

        public MathExpression(string expression, double result)
        {
            Expression = expression;
            Result = result;
        }
    }
}
