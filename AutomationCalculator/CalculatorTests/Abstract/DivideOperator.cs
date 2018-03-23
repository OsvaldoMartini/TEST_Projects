namespace CalculatorTests.Abstract
{
    internal class DivideOperator : BinaryOperator
    {
        public DivideOperator()
            : base(Operators.Divide)
        {
        }

        protected override int Evaluate(int left, int right)
        {
            return left / right;
        }
    }
}
