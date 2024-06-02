using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser.Common;

namespace ExpressionParser.Interfaces
{
    public interface IExpressionTree
    {
        Node Build(List<Token> tokens);
        Node Inorder(Node root);

    }
}
