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
        private Token? _nextToken;
        private INode? _expression;
        private Evaluator _evaluator;

        public Parser()
        {
            _evaluator = Evaluator.Instance;
        }

        public INode Parse(Queue<Token> tokens)
        {
            var root = ParseExpression(tokens);
            return root;
        }

        private INode ParseExpression(Queue<Token> tokens)
        {
            var left = ParseLeaf(tokens);

            if (_nextToken != null && (_nextToken._type == TokenType.Add || _nextToken._type == TokenType.Minus))
            {
                var operatorToken = _nextToken;
                Consume(tokens);
                NextToken(tokens);
                var right = ParseExpression(tokens);

                left = MakeBinary(operatorToken, left, right);
            }

            return left;
        }

        private INode ParseLeaf(Queue<Token> tokens)
        {
            var left = ParseFactor(tokens);

            if (_nextToken != null && (_nextToken._type == TokenType.Divide || _nextToken._type == TokenType.Multiply))
            {
                var operatorToken = _nextToken;
                Consume(tokens);
                NextToken(tokens);
                var right = ParseExpression(tokens);

                left = MakeBinary(operatorToken, left, right);
            }

            return left;
        }

        // TODO: Fix issues with ParseFactor (Including how I consume and peek at the next token)
        private INode ParseFactor(Queue<Token> tokens)
        {
            Consume(tokens);
            NextToken(tokens);
            var literal = new Node(_currentToken);
            return literal;
            //if (_currentToken != null && _currentToken._type == TokenType.Numeric)
            //{
            //    Consume(tokens);
            //    NextToken(tokens);
            //    var literal = new Node(_currentToken);
            //    return literal;
            //}

            //while (_currentToken != null && _currentToken._type != TokenType.RightParenthesis)
            //{
            //    _expression = ParseExpression(tokens);
            //}

            //return _expression;
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
        }

        private void NextToken(Queue<Token> tokens)
        {
            if (_currentToken == null || _currentToken._type == TokenType.EOF)
            {
                return;
            }

            _nextToken = tokens.Peek();
        }
    }
}
