using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample01
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {

        if (!CheckInputParameter(args[0]) || !CheckInputParameter(args[1]))
        {
          Console.WriteLine("Неверная параметризация");
          return;
        }

      int numberToConverted = Convert.ToInt32(args[0]);
      int numberSystemBase = Convert.ToInt32(args[1]);

      if (!(numberToConverted % 1 == 0)) Console.WriteLine("Первый параметр должен быть целым числом - нарушение требования");
      if (numberSystemBase<2 || numberSystemBase>20) Console.WriteLine("Второй параметр (основание системы счисления) должен быть в диапазоне от 2 до 20 - нарушение требования");

      Console.WriteLine(DecimalToArbitrarySystem(numberToConverted, numberSystemBase));

      Console.ReadKey();
      }
      catch (Exception ex)
      {
        Console.WriteLine("Ошибка выполнения: {0}", ex.Message);
      }
    }

    public static string DecimalToArbitrarySystem(long decimalNumber, int radix)
    {
      const int BitsInLong = 64;
      const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

      if (radix < 2 || radix > Digits.Length)
        throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());

      if (decimalNumber == 0)
        return "0";

      int index = BitsInLong - 1;
      long currentNumber = Math.Abs(decimalNumber);
      char[] charArray = new char[BitsInLong];

      while (currentNumber != 0)
      {
        int remainder = (int)(currentNumber % radix);
        charArray[index--] = Digits[remainder];
        currentNumber = currentNumber / radix;
      }

      string result = new String(charArray, index + 1, BitsInLong - index - 1);
      if (decimalNumber < 0)
      {
        result = "-" + result;
      }

      return result;
    }

    public static bool CheckInputParameter(string parameter)
    {
      bool checkResult = true;
      foreach (var ch in parameter)
      {
        if (ch != '0' &&
          ch != '1' &&
          ch != '2' &&
          ch != '3' &&
          ch != '4' &&
          ch != '5' &&
          ch != '6' &&
          ch != '7' &&
          ch != '8' &&
          ch != '9'
          )
        {
          checkResult = false;
          break;
        }
      }
      return checkResult;
    }
  }
}
