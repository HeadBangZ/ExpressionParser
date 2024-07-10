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

        public double Evaluate(INode node)
        {
            double a, b;

            switch (node.Data._type)
            {
                case TokenType.Numeric:
                    return Convert.ToDouble(node.Data._value);
                case TokenType.Add:
#pragma warning disable CS8604 // Possible null reference argument.
                    a = Evaluate(node.Left);
                    b = Evaluate(node.Right);
                    return a + b;
                case TokenType.Minus:
                    a = Evaluate(node.Left);
                    b = Evaluate(node.Right);
                    return a - b;
                case TokenType.Multiply:
                    a = Evaluate(node.Left);
                    b = Evaluate(node.Right);
                    return a * b;
                case TokenType.Divide:
                    a = Evaluate(node.Left);
                    b = Evaluate(node.Right);

                    if (b == 0)
                    {
                        throw new DivideByZeroException("Can not divide by zero");
                    }
                    return a / b;
                case TokenType.Power:
                    a = Evaluate(node.Left);
                    b = Evaluate(node.Right);
#pragma warning restore CS8604 // Possible null reference argument.

                    return Math.Pow(a, b);
                default:
                    throw new NotImplementedException($"Node of type {node.Data._type} is not implemented");
            };
        }
    }
}
