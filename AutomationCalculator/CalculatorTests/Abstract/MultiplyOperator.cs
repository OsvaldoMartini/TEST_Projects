namespace CalculatorTests.Abstract
{


    internal class MultiplyOperator : BinaryOperator
    {
        public MultiplyOperator()
            : base(Operators.Multiply)
        {
        }

        protected override int Evaluate(int left, int right)
        {
            return left * right;
        }
    }

}
