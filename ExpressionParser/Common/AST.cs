using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser.Interfaces;

namespace ExpressionParser.Common
{
    internal class AST : IExpressionTree
    {
        public Node Build(List<Token> tokens)
        {
            throw new NotImplementedException();
        }

        public Node Inorder(Node root)
        {
            throw new NotImplementedException();
        }
    }
}
