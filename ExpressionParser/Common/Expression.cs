using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser.Interfaces;

namespace ExpressionParser.Common
{
    internal class Expression : IEvaluable
    {
        public double Evaluate()
        {
            return 0;
        }

        private double EvaluateOperator(double left, double right, string op)
        {
            return op switch
            {
                "+" => left + right,
                "-" => left - right,
                "*" => left * right,
                "/" => left / right,
                "^" => Math.Pow(left, right),
                _ => throw new InvalidOperationException("Unsupported operator.")
            };
        }
    }
}
