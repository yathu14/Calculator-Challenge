namespace CalculatorTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void SingleNumber()
        {
            string oneValue = "2";

            var result = Calculator.Program.Add(oneValue);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TwoNumbers()
        {
            string twoValues = "2,3";

            var result = Calculator.Program.Add(twoValues);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void EmptyInput()
        {
            string emptyInput = "";

            var result = Calculator.Program.Add(emptyInput);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void InvalidValue()
        {
            string invalidValue = "2,t";

            var result = Calculator.Program.Add(invalidValue);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void MoreThanTwoValues()
        {
            string moreThanTwoValues = "2,3,4";

            var result = Calculator.Program.Add(moreThanTwoValues);
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void SupportNewLineCharacter()
        {
            string newLineCharacter = "1\\n2,3";

            var result = Calculator.Program.Add(newLineCharacter);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void DenyNegativeNumbers()
        {
            var negativeNumbers = "2,3,-4";
            string expectedErrorMessage = "Negative numbers not allowed, following are negative: -4";

            try
            {
                var result = Calculator.Program.Add(negativeNumbers);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(expectedErrorMessage, ex.Message);
            }
        }

        [TestMethod]
        public void InvalidateLargeNumbers()
        {
            string largeNumbers = "1,2,3,4,5,6,7,8,9,10,11,12,1001,2005";
            
            var result = Calculator.Program.Add(largeNumbers);
            Assert.AreEqual(78, result);
        }
    }
}