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
        Queue<Token> Tokenize(string expression);

        INode Parse(Queue<Token> tokens);
    }
}
