using CalculatorApi;
using NUnit;
using NUnit.Framework;
using Moq;

namespace CalculatorTests
{
    [TestFixture]
    public class Tests
    {
        SimpleCalculator calc;
        int num1;
        int num2;
        Mock<ILog> LogMoq;

        [SetUp]
        public void setUp()
        {
            LogMoq = new Mock<ILog>();
            SimpleCalculator a = new SimpleCalculator(LogMoq.Object);
            calc = a;
            num1 = 10;
            num2 = 5;
        }

        [Test]
        public void Addition()
        {

            int result = calc.add(num1, num2);
            int Expected = num1 + num2;
            LogMoq.Verify(log => log.LogMess($"{num1} + {num2} = {result}"), Times.Once);
            Assert.That(Expected.ToString(), Is.EqualTo(result.ToString()));

            int result2 = calc.add(num1, num2);
            int Expected2 = 2 + 3;
            Assert.That(Expected2.ToString(), Is.Not.EqualTo(result2.ToString()));
        }

        [Test]
        public void Multiplication()
        {
            
            int result = Convert.ToInt32(calc.multiply(num1, num2));
            int Expected = num1 * num2;
            LogMoq.Verify(log => log.LogMess($"{num1} * {num2} = {result}"), Times.Once);
            Assert.That(true, Expected.ToString(), result.ToString());

            int result2 = Convert.ToInt32(calc.multiply(num1, num2));
            int Expected2 = 2 * 3;
            Assert.That(Expected2.ToString(), Is.Not.EqualTo(result2.ToString()));
        }

        [Test]
        public void Division()
        {
            int result = calc.divide(num1, num2);
            int Expected = num1 / num2;
            LogMoq.Verify(log => log.LogMess($"{num1} / {num2} = {result}"), Times.Once);
            Assert.That(true, Expected.ToString(), result.ToString());

            int result2 = calc.divide(num1, num2);
            int Expected2 = 10 / 2;
            Assert.That(Expected2.ToString(), Is.Not.EqualTo(result2.ToString()));

        }

        [Test]
        public void Subtraction()
        {
            int result = calc.subtract(num1, num2);
            int Expected = num1 - num2;
            LogMoq.Verify(log => log.LogMess($"{num1} - {num2} = {result}"), Times.Once);
            Assert.That(true, Expected.ToString(), result.ToString());

            int result2 = calc.subtract(num1, num2);
            int Expected2 = 12 - 2;
            Assert.That(Expected2.ToString(), Is.Not.EqualTo(result2.ToString()));
        }

    }
}
