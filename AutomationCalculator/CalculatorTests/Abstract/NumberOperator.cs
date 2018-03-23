namespace CalculatorTests.Abstract
{
    internal class NumberOperator : Operator
    {
        public NumberOperator(int number)
            : base(null)
        {
            _number = number;
        }

        public override int Evaluate(EvaluateOption option, Calculator calculator)
        {
            return _number;
        }

        private readonly int _number;
    }
}
