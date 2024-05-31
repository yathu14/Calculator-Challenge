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
        public void MoreThanTwoValuesException()
        {
           string expectedErrorMessage = "Only maximum of 2 numbers allowed";
           var result = Assert.ThrowsException<Exception>(() => Calculator.Program.Add(moreThanTwoValues));
           Assert.AreEqual(expectedErrorMessage, result.Message);
        }
    }
}