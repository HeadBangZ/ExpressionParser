using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser.Common.Enums;
using ExpressionParser.Interfaces;

namespace ExpressionParser.Common
{
    public class Parser : IParser
    {
        private Token _currentToken;
        private Evaluator _evaluator;

        public Parser()
        {
            _evaluator = Evaluator.Instance;
        }

        public INode Parse(Queue<Token> tokens)
        {
            _currentToken = tokens.Count > 0 ? tokens.Dequeue() : new Token(TokenType.EOF, null);
            var root = ParseExpression(tokens);
            return root;
        }

        public Queue<Token> Tokenize(string expression)
        {
            List<Token> tokens = new List<Token>();

            int i = 0;

            while (i < expression.Length)
            {
                char c = expression[i];

                switch (c)
                {
                    case ' ':
                    case '\t':
                    case '\r':
                    case '\n':
                        i++;
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '^':
                        tokens.Add(new Token(TokenType.Operator, c));
                        i++;
                        break;
                    case '(':
                        tokens.Add(new Token(TokenType.LeftParenthesis, c));
                        i++;
                        break;
                    case ')':
                        tokens.Add(new Token(TokenType.RightParenthesis, c));
                        i++;
                        break;
                    default:
                        if (char.IsDigit(c))
                        {
                            StringBuilder sb = new StringBuilder();
                            while (i < expression.Length && char.IsDigit(expression[i]))
                            {
                                sb.Append(expression[i]);
                                i++;
                            }

                            double number;

                            if (!double.TryParse(sb.ToString(), out number))
                            {
                                throw new FormatException($"Invalid number format: {sb}");
                            }

                            tokens.Add(new Token(TokenType.ValueData, number));
                        }
                        else
                        {
                            i++;
                        }
                        break;

                }
            }

            return new Queue<Token>(tokens);
        }

        private INode ParseExpression(Queue<Token> tokens)
        {
            var left = ParseTerm(tokens);

            return null;
        }

        private INode ParseTerm(Queue<Token> tokens)
        {
            var left = ParseFactor(tokens);

            return null;
        }

        private INode ParseFactor(Queue<Token> tokens)
        {
            return null;
        }

        private void Match()
        {

        }
    }
}
