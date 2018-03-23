namespace CalculatorTests.Abstract
{
    internal class SubtractOperator : BinaryOperator
    {
        public SubtractOperator()
            : base(Operators.Subtract)
        {
        }

        protected override int Evaluate(int left, int right)
        {
            return left - right;
        }
    }
}
