using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorTests.Interfaces
{
    internal interface IOperand
    {
        int Evaluate(EvaluateOption option, Calculator calculator);
    }
}
