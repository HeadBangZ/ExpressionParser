using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser.Common;

namespace ExpressionParser.Interfaces
{
    public interface INode
    {
        INode? Left { get; set; }
        INode? Right { get; set; }
        Token Data { get; set; }
    }
}
