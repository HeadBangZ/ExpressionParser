using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Common.Enums
{
    public enum TokenType
    {
        Add,
        Minus,
        Divide,
        Multiply,
        Power,
        Numeric,
        LeftParenthesis,
        RightParenthesis,
        EOF,
    }
}
