using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
  public class Calculator
  {
    public double Sum(double fistNumber, double secondNumber)
    {
      return RoundNumber(fistNumber + secondNumber);
    }

    public double Subtract(double fistNumber, double secondNumber)
    {
      return RoundNumber(fistNumber - secondNumber);
    }

    public double Multiply(double fistNumber, double secondNumber)
    {
      return RoundNumber(fistNumber * secondNumber);
    }

    public double Divide(double fistNumber, double secondNumber)
    {
      if (secondNumber == 0)
        throw new ArgumentException("Cannot divide by zero");
      else return RoundNumber(fistNumber / secondNumber);
    }

    public double Pow(double number, double power)
    {
      if (power % 1 == 0 && power >= 1)
      {
        var initialNumber = number;
        for (int i = 1; i <= power - 1; i++) number *= initialNumber;
        return RoundNumber(number);
      }
      else
        return RoundNumber(Math.Pow(number, power));
    }

    public double Sqrt(double number)
    {
      if (number < 0)
        throw new ArgumentException("Cannot extract sqrt from negative number");

      double temporarySqrt;
      double squareRoot = number/2;
      do
      {
        temporarySqrt = squareRoot;
        squareRoot = (temporarySqrt + (number/ temporarySqrt))/2;
      } while ((temporarySqrt - squareRoot) != 0);

      return RoundNumber(squareRoot);
    }

    private double RoundNumber(double operationResult)
    {
      return Math.Round(operationResult, 5);
    }
  }
}
