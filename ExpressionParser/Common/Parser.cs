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

            NextToken(tokens);

            if (_nextToken._type == TokenType.Operator)
            {
                var operatorToken = _nextToken;
                Consume(tokens);
                NextToken(tokens);
                var right = ParseExpression(tokens);

                return MakeBinary(operatorToken, left, right);
            }
            else
            {
                return left;
            }
        }

        private INode ParseLeaf(Queue<Token> tokens)
        {
            Consume(tokens);
            NextToken(tokens);
            return new Node(_currentToken);
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
            if (_currentToken._type == TokenType.EOF)
            {
                return;
            }

            _nextToken = tokens.Peek();
        }
    }
}
