using ExpressionParser.Common;

namespace ExpressionParser.Tests
{
    public class Example
    {
        [Fact]
        public void Test1()
        {
            var ep = new Parser();
            var result = ep.Tokenize(@"10 + 5    - aaa3 / 5 \ 3");

            //ep.Parse(@"10 +* 5    -- aaa3 / 5 \ 3");
            var r1 = ep.Tokenize(@"10 +* 5    - aaa3 / 5 \ 3");

            Assert.True(result.Count() > 0);
            Assert.True(r1.Count() > 0);
        }
    }
}
