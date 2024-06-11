using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser.Common.Enums;
using ExpressionParser.Interfaces;

namespace ExpressionParser.Common
{
    public sealed class Evaluator : IEvaluable
    {
        private static readonly Evaluator _instance = new Evaluator();

        static Evaluator() { }

        private Evaluator() { }

        public static Evaluator Instance
        {
            get
            {
                return _instance;
            }
        }

        public double Evaluate(double left, double right, string op)
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

        public int GetPrecedence(Token token)
        {
            return token._value switch
            {
                "^" => 3,
                "*" => 2,
                "/" => 2,
                "+" => 1,
                "-" => 1,
                _ => 0
            };
        }
    }
}
