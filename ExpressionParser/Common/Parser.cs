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
        private Token? _currentToken;

        public Parser()
        {
        }

        public INode Parse(Queue<Token> tokens)
        {
            Consume(tokens);
            return ParseExpression(tokens);
        }

        private INode ParseExpression(Queue<Token> tokens)
        {
            var left = ParseMultiplyDivide(tokens);

            while (_currentToken != null && (_currentToken._type == TokenType.Add || _currentToken._type == TokenType.Minus))
            {
                var operatorToken = _currentToken;
                Consume(tokens);
                var right = ParseMultiplyDivide(tokens);
                left = MakeBinary(operatorToken, left, right);
            }

            return left;
        }

        private INode ParseMultiplyDivide(Queue<Token> tokens)
        {
            var left = ParsePower(tokens);

            while (_currentToken != null && (_currentToken._type == TokenType.Multiply || _currentToken._type == TokenType.Divide))
            {
                var operatorToken = _currentToken;
                Consume(tokens);
                var right = ParsePower(tokens);
                left = MakeBinary(operatorToken, left, right);
            }

            return left;
        }

        private INode ParsePower(Queue<Token> tokens)
        {
            var left = ParseFactor(tokens);

            while (_currentToken != null && (_currentToken._type == TokenType.Power))
            {
                var operatorToken = _currentToken;
                Consume(tokens);
                var right = ParseFactor(tokens);
                left = MakeBinary(operatorToken, left, right);
            }

            return left;
        }

        private INode ParseFactor(Queue<Token> tokens)
        {
            if (_currentToken != null && _currentToken._type == TokenType.Numeric)
            {
                var literal = new Node(_currentToken);
                Consume(tokens);
                return literal;
            }

            if (_currentToken != null && _currentToken._type == TokenType.LeftParenthesis)
            {
                Consume(tokens);
                var expression = ParseExpression(tokens);

                if (_currentToken == null || _currentToken._type != TokenType.RightParenthesis)
                {
                    throw new InvalidOperationException("Missing closing parenthesis");
                }

                Consume(tokens);
                return expression;
            }

            if (_currentToken._type == TokenType.EOF) return new Node(_currentToken);

            throw new InvalidOperationException("Missing EOF token");
        }

        private INode MakeBinary(Token token, INode left, INode right)
        {
            return new Node(token, left, right);
        }

        private void Consume(Queue<Token> tokens)
        {
            if (tokens.Count > 0)
            {
                _currentToken = tokens.Dequeue();
            }
            else
            {
                _currentToken = null;
            }
        }
    }
}
