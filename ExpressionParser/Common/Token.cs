using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser.Common.Enums;

namespace ExpressionParser.Common
{
    public class Token
    {
        public readonly TokenType _type;
        public readonly object? _value;

        public Token(TokenType type, object value)
        {
            _type = type;

            if (value is char || value is double || value is null)
            {
                _value = value;
            }
            else
            {
                throw new ArgumentException("Value must either be a char or a double");
            }
        }

        public override string ToString()
        {
            return $"{_type} : {_value}";
        }
    }
}
