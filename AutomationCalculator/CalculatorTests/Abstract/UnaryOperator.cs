using System;
using CalculatorTests.Interfaces;

namespace CalculatorTests.Abstract
{

    internal abstract class UnaryOperator : Operator
    {
        public UnaryOperator(string automationName)
            : base(automationName)
        {
        }

        public IOperand Operand { get; set; }

        public override int Evaluate(EvaluateOption option, Calculator calculator)
        {
            if (Operand == null)
            {
                throw new InvalidOperationException();
            }

            int result = 0;

            switch (option)
            {
                case EvaluateOption.UIEvaluate:

                    calculator.Clear();

                    int operandEval = Operand.Evaluate(option, calculator);

                    calculator.Clear();

                    calculator.Result = operandEval;

                    InvokeOperator(calculator);

                    calculator.Evaluate();

                    result = int.Parse(calculator.Result.ToString());

                    break;
                case EvaluateOption.ActualEvaluate:
                    result = Evaluate(Operand.Evaluate(option, calculator));
                    break;
            }

            return result;
        }

        protected abstract int Evaluate(int operand);
    }

}
