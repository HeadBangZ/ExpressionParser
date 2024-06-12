using ExpressionParser.Common;

namespace ExpressionParser.Tests
{
    public class Example
    {
        [Fact]
        public void Test1()
        {
            var lexer = new Lexer();
            var parser = new Parser();

            var tokens1 = lexer.Tokenize(@"10 + 5    - aaa3 / 5 \ 3");
            var tokens2 = lexer.Tokenize(@"10 +* 5    - aaa3 / 5 \ 3");

            Assert.True(tokens1.Count() > 0);
            Assert.True(tokens2.Count() > 0);
        }
    }
}
