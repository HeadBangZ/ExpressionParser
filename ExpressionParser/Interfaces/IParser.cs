using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser.Common;

namespace ExpressionParser.Interfaces
{
    internal interface IParser
    {
        List<Token> Tokenize(string expression);

        INode Parse(List<Token> tokens);
    }
}
