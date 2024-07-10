using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser.Common;
using ExpressionParser.Common.Enums;

namespace ExpressionParser.Tests
{
    public class ExpressionParserTests
    {
        private Lexer _lexer;
        private Parser _parser;
        private Evaluator _evaluator;

        public ExpressionParserTests()
        {
            _lexer = new Lexer();
            _parser = new Parser();
            _evaluator = Evaluator.Instance;
        }

        [Fact]
        public void Lexer_Tokenization_IncorrectLength()
        {
            var expression = "5 + 3 * ( 10 - 4 )";
            var queue = _lexer.Tokenize(expression);
            Assert.NotNull(queue);
            Assert.NotEqual(expression.Split(' ').Length, queue.Count);
        }

        [Fact]
        public void Lexer_Tokenization_CorrectLength()
        {
            var expression = "5 + 3 * ( 10 - 4 )";
            var queue = _lexer.Tokenize(expression);
            Assert.NotNull(queue);
            Assert.Equal(expression.Split(' ').Length + 1, queue.Count);
        }

        [Fact]
        public void Lexer_Tokenization_LastTokenEOF()
        {
            var expression = "5 + 3 * ( 10 - 4 )";
            var tokenList = _lexer.Tokenize(expression).ToList();
            var lastToken = tokenList.Last();
            Assert.Null(lastToken._value);
            Assert.Equal(TokenType.EOF, lastToken._type);
        }

        [Fact]
        public void Parser_Parse_Success()
        {
            var expression = "5+    3/(5*6+(2+3-7)/(    3  -2   +7))+2^2)";
            var queue = _lexer.Tokenize(expression);
            Assert.NotNull(queue);
            var root = _parser.Parse(queue);
            Assert.NotNull(root);
            var lastItem = queue.Last();
            Assert.Single(queue);
            Assert.Equal(TokenType.EOF, lastItem._type);
            Assert.NotNull(lastItem);
        }

        [Fact]
        public void Parser_Parse_FirstTokenTypeAdd()
        {
            var expression = "5 + 3 * ( 10 - 4 )";
            var queue = _lexer.Tokenize(expression);
            var root = _parser.Parse(queue);
            Assert.NotNull(root);
            Assert.NotNull(root.Left);
            Assert.NotNull(root.Right);
            Assert.Equal("+", root.Data._value.ToString());
            Assert.Equal(TokenType.Add, root.Data._type);
        }

        [Fact]
        public void Parser_Parse_MissingEOFToken()
        {
            var expression = "Console.WriteLine('Hello world!');";
            var queue = _lexer.Tokenize(expression);

            var exception = Assert.Throws<InvalidOperationException>(() => _parser.Parse(queue));

            Assert.Equal("Missing EOF token", exception.Message);
        }

        [Fact]
        public void Parser_Parse_MissingClosingParenthesis()
        {
            var expression = "5 + 3 * ( 10 - 4 ";
            var queue = _lexer.Tokenize(expression);

            var exception = Assert.Throws<InvalidOperationException>(() => _parser.Parse(queue));

            Assert.Equal("Missing closing parenthesis", exception.Message);
        }

        [Fact]
        public void Evaluator_Evaluate_IsNumeric()
        {
            var root = new Node(
                new Token(
                    TokenType.Numeric,
                    5.00
                )
            );

            var result = _evaluator.Evaluate(root);

            Assert.IsType<double>(result);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Evaluator_Evaluate_IsAdd()
        {
            var root = new Node(
                new Token(
                    TokenType.Add,
                    '+'
                ),
                new Node(
                    new Token(
                        TokenType.Numeric,
                        3.00
                    )
                ),
                new Node(
                    new Token(
                        TokenType.Numeric,
                        5.00
                    )
                )
            );

            var result = _evaluator.Evaluate(root);

            Assert.IsType<double>(result);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Evaluator_Evaluate_IsMinus()
        {
            var root = new Node(
                new Token(
                    TokenType.Minus,
                    '-'
                ),
                new Node(
                    new Token(
                        TokenType.Numeric,
                        3.00
                    )
                ),
                new Node(
                    new Token(
                        TokenType.Numeric,
                        5.00
                    )
                )
            );

            var result = _evaluator.Evaluate(root);

            Assert.IsType<double>(result);
            Assert.Equal(-2, result);
        }

        [Fact]
        public void Evaluator_Evaluate_IsMultiply()
        {
            var root = new Node(
                new Token(
                    TokenType.Multiply,
                    '*'
                ),
                new Node(
                    new Token(
                        TokenType.Numeric,
                        3.00
                    )
                ),
                new Node(
                    new Token(
                        TokenType.Numeric,
                        5.00
                    )
                )
            );

            var result = _evaluator.Evaluate(root);

            Assert.IsType<double>(result);
            Assert.Equal(15, result);
        }

        [Fact]
        public void Evaluator_Evaluate_IsDivide()
        {
            var root = new Node(
                new Token(
                    TokenType.Divide,
                    '/'
                ),
                new Node(
                    new Token(
                        TokenType.Numeric,
                        3.00
                    )
                ),
                new Node(
                    new Token(
                        TokenType.Numeric,
                        5.00
                    )
                )
            );

            var result = _evaluator.Evaluate(root);

            Assert.IsType<double>(result);
            Assert.Equal(0.6, result);
        }

        [Fact]
        public void Evaluator_Evaluate_IsPower()
        {
            var root = new Node(
                new Token(
                    TokenType.Power,
                    '^'
                ),
                new Node(
                    new Token(
                        TokenType.Numeric,
                        3.00
                    )
                ),
                new Node(
                    new Token(
                        TokenType.Numeric,
                        2.00
                    )
                )
            );

            var result = _evaluator.Evaluate(root);

            Assert.IsType<double>(result);
            Assert.Equal(9, result);
        }

        [Fact]
        public void Evaluator_Evaluate_DivideByZeroException()
        {
            var root = new Node(
                new Token(
                    TokenType.Divide,
                    '/'
                ),
                new Node(
                    new Token(
                        TokenType.Numeric,
                        2.00
                    )
                ),
                new Node(
                    new Token(
                        TokenType.Numeric,
                        0.00
                    )
                )
            );

            var exception = Assert.Throws<DivideByZeroException>(() => _evaluator.Evaluate(root));
            Assert.Equal("Can not divide by zero", exception.Message);
        }
    }
}
