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
        public INode Parent { get; set; }
        public INode Left { get; set; }
        public INode Right { get; set; }
        public TokenType DataType { get; set; }

        private object _value;

        public object Value
        {
            get => _value;
            set
            {
                if (value is char || value is double)
                {
                    _value = value;
                }
                else
                {
                    throw new ArgumentException("Value must either be a char or a double");
                }
            }
        }

        public Node(TokenType type, object value)
        {
            DataType = type;
            _value = value;
        }

        public double Evaluate()
        {
            return 0;
        }
    }
}
