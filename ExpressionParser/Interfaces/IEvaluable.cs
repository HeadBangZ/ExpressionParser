using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser.Common;

namespace ExpressionParser.Interfaces
{
    public interface IEvaluable
    {
        double Evaluate(double left, double right, string op);

        int GetPrecedence(Token token);
    }
}
