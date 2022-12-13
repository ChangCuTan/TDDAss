using CauculationByString;

namespace TDDAss
{
    [TestClass]
    public class UnitTestStringCalculator
    {

        [TestMethod]
        public void TestStringCalculatorSimpleAdd()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int result = stringCalculator.Add("1,1");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestAddOneNumberOnly()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int result = stringCalculator.Add("1");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestAddWithDifferentDelimiters()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int result = stringCalculator.Add("//[***]\n1***2***3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void TestAddNegitiveInput()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int result = stringCalculator.Add("//;\n-1;2");
        }

        [TestMethod]
        public void TestAddIgnoreMoreThan1001()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int result = stringCalculator.Add("1001,2");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestAddStingEmpty()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int result = stringCalculator.Add("");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestAddUnknownNumbers()
        {
            StringCalculator stringCalculator = new StringCalculator();
            string userInput = "";
            int expected = 0;
            Random rnd = new Random();
            int counts = rnd.Next(90, 100);
            
            for (int i = counts; i >= 0; i--)
            {
                int numbers = rnd.Next(90, 100);
                if (i != 0)
                {
                    userInput = userInput + numbers + ",";
                }
                else
                {
                    userInput = userInput + numbers;
                }
                expected = expected + numbers;

            }

            int result = stringCalculator.Add(userInput);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAddWithNewLine()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int result = stringCalculator.Add("1\n2,3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void TestAddMutipleDelimiter() 
        {
            StringCalculator stringCalculator = new StringCalculator();
            int result = stringCalculator.Add("//[*][%]\n1*2%3");
            Assert.AreEqual(6, result);
        }
    }
}