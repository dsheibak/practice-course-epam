using NUnit.Framework;
using SimpleCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorTests
{
  [TestFixture]
  [Parallelizable(ParallelScope.Fixtures)]
  public class CalculatorTests
  {
    public Calculator calculator;

    private static IEnumerable<TestCaseData> TestCaseData()
    {
      yield return new TestCaseData(202.510524, -29289.292893, -29086.78237);
      yield return new TestCaseData(0, 0, 0);
      yield return new TestCaseData(0.283737823, 0.0000003, 0.28374);
      yield return new TestCaseData(-99999, 0.0002003, -99998.9998);
      yield return new TestCaseData(-1, -1, -2);
    }

    [SetUp]
    public void CalculatorSetup()
    {
      calculator = new Calculator();
    }

    [Test]
    public void ExceptionWhenDivideByZeroCanBeRaised()
    {
      var firstNumber = 77;
      var secondNumber = 0;

      Assert.Throws<ArgumentException>(() => calculator.Divide(firstNumber, secondNumber));
    }

    [Test]
    public void SumOfTwoNumbersCanBeCorrectlyCalculated()
    {
      var firstNumber = 66;
      var secondNumber = 0;
      var expectedSum = Math.Round((double)firstNumber + secondNumber, 5);

      Assert.True(calculator.Sum(firstNumber, secondNumber) == expectedSum);
    }

    [Test]
    public void MultiplyOfTwoNumbersCanBeCorrectlyCalculated()
    {
      var firstNumber = -6;
      var secondNumber = -6;
      var expectedMultiplication = Math.Round((double)firstNumber * secondNumber, 5);

      Assert.True(calculator.Multiply(firstNumber, secondNumber) == expectedMultiplication);
    }

    [Test]
    public void ResultSubstraction_CorrectlyDetected_And_IsNegative_When_FirstOperandLessThanSecond()
    {
      var firstNumber = 0.004834778;
      var secondNumber = 1.2388478;
      var expectedSubtraction = Math.Round((double)firstNumber - secondNumber, 5);

      Assert.True(calculator.Subtract(firstNumber, secondNumber) == expectedSubtraction && expectedSubtraction < 0);
    }

    [Test]
    public void ResultSubstraction_CorrectlyDetected_And_IsPositive_When_SecondOperandLessThanFirst()
    {
      var firstNumber = 675.333;
      var secondNumber = 544.89323;
      var expectedSubtraction = Math.Round((double)firstNumber - secondNumber, 5);

      Assert.True(calculator.Subtract(firstNumber, secondNumber) == expectedSubtraction && expectedSubtraction > 0);
    }

    [Test]
    public void DivisionOfTwoNumbersCanBeCorrectlyCalculated()
    {
      var firstNumber = 12.757457;
      var secondNumber = 5.9766634;
      var expectedDivision = Math.Round((double)firstNumber / secondNumber, 5);

      Assert.True(calculator.Divide(firstNumber, secondNumber) == expectedDivision);
    }

    [Test]
    public void PowOfTwoNumbersCanBeCorrectlyCalculated()
    {
      var firstNumber = 34.3235;
      var secondNumber = 2.302010;
      var expectedPow = Math.Round(Math.Pow((double)firstNumber, (double)secondNumber), 5);

      Assert.True(calculator.Pow(firstNumber, secondNumber) == expectedPow);
    }

    [Test]
    public void RaisingToFirstDegreeCanBeCorrectlyCalculated()
    {
      var firstNumber = 34.3235;
      var secondNumber = 1;
      var expectedPow = Math.Round(Math.Pow((double)firstNumber, (double)secondNumber), 5);

      Assert.True(calculator.Pow(firstNumber, secondNumber) == expectedPow);
    }

    [Test]
    public void RaisingToNaturalDegreeCanBeCorrectlyCalculated()
    {
      var firstNumber = 2;
      var secondNumber = 32;
      var expectedPow = Math.Round(Math.Pow((double)firstNumber, (double)secondNumber), 5);

      Assert.True(calculator.Pow(firstNumber, secondNumber) == expectedPow);
    }

    [Test]
    public void SqrtOfNumberCanBeCorrectlyCalculated()
    {
      var number = 948.979;
      var expectedSqrt = Math.Round(Math.Sqrt((double)number), 5);

      Assert.True(calculator.Sqrt(number) == expectedSqrt);
    }

    [Test]
    public void ExceptionWhenSqrtOfNegatibeNumberCanBeRaised()
    {
      var number = -100.387211;

      Assert.Throws<ArgumentException>(() => calculator.Sqrt(number));
    }
    

    [Test, TestCaseSource("TestCaseData")]
    public void SumOfTwoNumbersCanBeCorrectlyCalculatedUsingTestCaseSource(double firstNumber, double secondNumber, double expectedSum)
    {
      Assert.True(calculator.Sum(firstNumber, secondNumber) == expectedSum);
    }
  }
}