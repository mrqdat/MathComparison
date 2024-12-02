﻿using MathComparison.src.Application.DTOs;
using MathComparison.src.Domain.Interfaces;
using Mathos.Parser;

namespace MathComparison.src.Application.Services
{
    public class MathComparisonService : IMathExpressionService
    {
        private static readonly Random random = new();

        public bool EvaluateComparison(ComparisionRequest request)
        {
            var value1 = string.IsNullOrEmpty(request.Expression1) == true ? 0 : EvaluateExpression(request.Expression1);
            var value2 = string.IsNullOrEmpty(request.Expression2) == true ? 0 : EvaluateExpression(request.Expression2);

            return request.Operator switch
            {
                "<" => value1 < value2,
                ">" => value1 > value2,
                "=" => Math.Abs(value1 - value2) < 0.00001,
                _ => throw new ArgumentException("invalid operator")
            };
        }

        public (string Expression1, string Expression2) GenerateExpressions(string difficulty)
        {
            return difficulty switch
            {
                "ez" => (GenerateSimpleNumber(), GenerateSimpleNumber()),
                "normal" => (GenerateSimpleExpression(), GenerateSimpleExpression()),
                "hard" => (GenerateComplexExpression(), GenerateComplexExpression()),
                _ => throw new ArgumentException("invalid difficulty")

            };
        }

        public static string GenerateSimpleNumber()
        {
            return random.Next(1, 1000).ToString();
        }

        public static string GenerateSimpleExpression()
        {
            var leftvalue = random.Next(1, 100);
            var rightvalue = random.Next(1, 100);
            var opr = new[] { "+", "-", "*", "/" };

            var randomOpr = opr[random.Next(opr.Length)];

            return $"{leftvalue} {randomOpr} {rightvalue}";
        }

        public static string GenerateComplexExpression()
        {
            var expression = GenerateSimpleExpression();
            var additionalexpression = GenerateSimpleExpression();

            return $"{expression} {new[] { "+", "-" }[random.Next(2)]} ({additionalexpression}) ";
        }

        private static double EvaluateExpression(string expression)
        {
            try
            {
                var data = new MathParser().Parse(expression);
                return Convert.ToDouble(data);
            }
            catch
            {
                throw new InvalidOperationException("Invalid mathematical expression");
            }
        }
    }
}
