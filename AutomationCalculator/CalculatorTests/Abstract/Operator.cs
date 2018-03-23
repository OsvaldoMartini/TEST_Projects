using CalculatorTests.Interfaces;

namespace CalculatorTests.Abstract
{
    internal abstract class Operator : IOperand
    {
        internal Operator(string automationName)
        {
            AutomationName = automationName;
        }

        public string AutomationName { private set; get; }

        public abstract int Evaluate(EvaluateOption option, Calculator calculator);

        protected virtual void InvokeOperator(Calculator calculator)
        {
            calculator.InvokeFunction(AutomationName);
        }
    }
}
