using System;
using CalculatorTests.Interfaces;

namespace CalculatorTests.Abstract
{

    internal abstract class BinaryOperator : Operator
    {
        public BinaryOperator(string automationName)
            : base(automationName)
        {
        }

        public IOperand Left { get; set; }

        public IOperand Right { get; set; }

        public override int Evaluate(EvaluateOption option, Calculator calculator)
        {
            VerifyEvaluationState();

            int result = 0;

            switch (option)
            {
                case EvaluateOption.UIEvaluate:

                    calculator.Clear();
                    int leftValue = Left.Evaluate(option, calculator);

                    calculator.Clear();
                    int rightValue = Right.Evaluate(option, calculator);

                    calculator.Clear();

                    calculator.Result = leftValue;

                    InvokeOperator(calculator);

                    calculator.Result = rightValue;

                    calculator.Evaluate();

                    result = int.Parse(calculator.Result.ToString());

                    break;

                case EvaluateOption.ActualEvaluate:
                    result = Evaluate(Left.Evaluate(option, calculator), Right.Evaluate(option, calculator));
                    break;
            }

            return result;
        }

        protected void VerifyEvaluationState()
        {
            if ((Left == null) || (Right == null))
            {
                throw new InvalidOperationException();
            }
        }

        protected abstract int Evaluate(int left, int right);
    }

}
