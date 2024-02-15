using NUnit.Framework;

namespace StretchyCalculator
{
    [TestFixture]
    public class CalculatorTest
    {
        #region Division Tests
        [Test]
        public void Division()
        {
            float operandA = 18.0f;
            float operandB = 1.5f;

            ICalculatorEngine calculator = new Calculator();

            Assert.AreEqual(12.0f, calculator.Divide(operandA,operandB));
        }

        [Test]
        public void DivisionByZero()
        {
            float operandA = 18.0f;
            float operandB = 0f;

            ICalculatorEngine calculator = new Calculator();

            Assert.AreEqual(float.PositiveInfinity, calculator.Divide(operandA, operandB));
        }

        [Test]
        public void DivisionByZeroNegative()
        {
            float operandA = -18.0f;
            float operandB = 0f;

            ICalculatorEngine calculator = new Calculator();

            Assert.AreEqual(float.NegativeInfinity, calculator.Divide(operandA, operandB));
        }

        [Test]
        public void DivisionUnderflow()
        {
            float operandA = float.Epsilon;
            float operandB = 2.0f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(0.0f, calculator.Divide(operandA, operandB));
        }

        [Test]
        public void DivisionMinimumValue()
        {
            float operandA = float.MinValue;
            float operandB = 1.0f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(float.MinValue, calculator.Divide(operandA, operandB));
        }
        #endregion

        #region Multiplication Tests
        [Test]
        public void Multiplication()
        {
            float operandA = 18.0f;
            float operandB = 1.5f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(27.0f, calculator.Multiply(operandA, operandB));
        }

        [Test]
        public void MultiplicationNegative()
        {
            float operandA = -18.0f;
            float operandB = 1.5f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(-27.0f, calculator.Multiply(operandA, operandB));
        }

        [Test]
        public void MultiplicationNegativeToPositive()
        {
            float operandA = -18.0f;
            float operandB = -1.5f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(27.0f, calculator.Multiply(operandA, operandB));
        }

        [Test]
        public void MultiplicationOverflow()
        {
            float operandA = float.MaxValue;
            float operandB = 1.5f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(float.PositiveInfinity, calculator.Multiply(operandA, operandB));
        }
        #endregion

        #region Subtraction Tests
        [Test]
        public void Subtraction()
        {
            float operandA = 18.0f;
            float operandB = 1.5f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(16.5f, calculator.Subtract(operandA, operandB));
        }

        [Test]
        public void SubtractionToNegative()
        {
            float operandA = 18.0f;
            float operandB = 19.5f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(-1.5f, calculator.Subtract(operandA, operandB));
        }

        [Test]
        public void SubtractionNegative()
        {
            float operandA = -18.0f;
            float operandB = -1.5f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(-16.5f, calculator.Subtract(operandA, operandB));
        }

        [Test]
        public void SubtractionUnderflow()
        {
            float operandA = float.MinValue;
            float operandB = 1.0f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(float.MinValue, calculator.Subtract(operandA, operandB));
        }
        #endregion

        #region Addition Tests
        [Test]
        public void Addition()
        {
            float operandA = 18.0f;
            float operandB = 1.5f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(19.5f, calculator.Add(operandA, operandB));
        }

        [Test]
        public void AdditionToPositive()
        {
            float operandA = 18.0f;
            float operandB = -1.5f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(16.5f, calculator.Add(operandA, operandB));
        }

        [Test]
        public void AdditionNegative()
        {
            float operandA = -18.0f;
            float operandB = -1.5f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(-19.5f, calculator.Add(operandA, operandB));
        }

        [Test]
        public void AdditionOverflow()
        {
            float operandA = float.MaxValue;
            float operandB = 1.5f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(float.MaxValue, calculator.Add(operandA, operandB));
        }
        #endregion

        #region Sqrt Tests
        [Test]
        public void SquareRoot()
        {
            float operandA = 169.0f;
            
            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(13.0f, calculator.sqrt(operandA));
        }

        [Test]
        public void SquareRootUnderflow()
        {
            float operandA = float.MinValue;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(float.NaN, calculator.sqrt(operandA));
        }

        [Test]
        public void SquareRootNegative()
        {
            float operandA = -169.0f;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(float.NaN, calculator.sqrt(operandA));
        }

        [Test]
        public void SquareRootInfinitiy()
        {
            float operandA = float.PositiveInfinity;

            ICalculatorEngine calculator = new Calculator();
            Assert.AreEqual(float.PositiveInfinity, calculator.sqrt(operandA));
        }
                
        #endregion
    }
}
