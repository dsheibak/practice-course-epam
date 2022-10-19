//Написать программу, которая принимает из командной строки последовательность символов (строку) в качестве аргумента
//И выводит в консоль максимальное количество неодинаковых последовательных символов в строке

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAndBuildToolsTask
{
  class Program
  {
    static void Main(string[] args)
    {
      int unequalchar = 0;

      string input_str = args[0];
      char[] chararr = input_str.ToCharArray(); 

      List<int> unequalchararr = new List<int>();

      char[] subpart = { };

      for (int i = 0; i < chararr.Length; i++)
      {

        unequalchar = 1;
        subpart = input_str.Substring(i).ToCharArray();

        for (int j = 0; j < subpart.Length-1; j++)
        {
          if (subpart[j] == subpart[j + 1]) break;
          else unequalchar++;
        }

        unequalchararr.Add(unequalchar); 
      }

      Console.WriteLine("Максимальное количество неодинаковых последовательных символов в строке: {0}", unequalchararr.Max());

      Console.ReadKey();
    }
  }
}
