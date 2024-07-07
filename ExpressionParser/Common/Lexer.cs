using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser.Common.Enums;
using ExpressionParser.Interfaces;

namespace ExpressionParser.Common
{
    public class Lexer : ILexer
    {
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
                        tokens.Add(new Token(TokenType.Add, c));
                        i++;
                        break;
                    case '-':
                        tokens.Add(new Token(TokenType.Minus, c));
                        i++;
                        break;
                    case '*':
                        tokens.Add(new Token(TokenType.Multiply, c));
                        i++;
                        break;
                    case '/':
                        tokens.Add(new Token(TokenType.Divide, c));
                        i++;
                        break;
                    case '^':
                        tokens.Add(new Token(TokenType.Power, c));
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

                            tokens.Add(new Token(TokenType.Number, number));
                        }
                        else
                        {
                            i++;
                        }
                        break;

                }
            }

            tokens.Add(new Token(TokenType.EOF, null));

            return new Queue<Token>(tokens);
        }
    }
}
