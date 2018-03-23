namespace CalculatorTests.Abstract
{

    internal class AddOperator : BinaryOperator
    {
        public AddOperator()
            : base(Operators.Add)
        {
        }

        protected override int Evaluate(int left, int right)
        {
            return left + right;
        }
    }
}
