using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser.Common.Enums;
using ExpressionParser.Interfaces;

namespace ExpressionParser.Common
{
    public class Node : INode
    {
        public INode? Parent { get; set; }
        public INode? Left { get; set; }
        public INode? Right { get; set; }
        public Token Data { get; set; }

        public Node(Token type)
        {
            Data = type;
        }

        public double Evaluate()
        {
            return 0;
        }
    }
}
