namespace CalculatorTests
{
    [TestClass]
    public class UnitTests
    {
        private const string emptyInput = "";
        private const string oneValue = "2";
        private const string twoValues = "2,3";
        private const string invalidValue = "2,t";
        private const string moreThanTwoValues = "2,3,4";
        private const string newLineCharacter = "1\\n2,3";

        [TestMethod]
        public void SingleNumber()
        {
            var result = Calculator.Program.Add(oneValue);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TwoNumbers()
        {
            var result = Calculator.Program.Add(twoValues);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void EmptyInput()
        {
            var result = Calculator.Program.Add(emptyInput);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void InvalidValue()
        {
            var result = Calculator.Program.Add(invalidValue);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void MoreThanTwoValues()
        {
            var result = Calculator.Program.Add(moreThanTwoValues);
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void SupportNewLineCharacter()
        {
            var result = Calculator.Program.Add(newLineCharacter);
            Assert.AreEqual(6, result);
        }
    }
}