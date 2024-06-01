using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser.Common.Enums;

namespace ExpressionParser.Interfaces
{
    public interface INode : IEvaluable
    {
        INode Parent { get; set; }
        INode Left { get; set; }
        INode Right { get; set; }
        TokenType DataType { get; set; }
    }
}
