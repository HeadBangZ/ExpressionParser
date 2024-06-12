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
