using NUnit.Framework;

[TestFixture]
public class CalculatorTest
{
    [Test]
    public void TestAdd()
    {
        Calculator calc = new Calculator();

        Assert.AreEqual(10, calc.Add(5, 5));
    }
}