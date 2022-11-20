using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 
using System.Threading;

namespace ConsoleApp3_2
{
  class Program
  {
    // объект событие с автосбросом - событие разрешения вывода четного числа
    static AutoResetEvent waitEvenHandler = new AutoResetEvent(true); 

    // объект событие с автосбросом - событие разрешения вывода нечетного числа
    static AutoResetEvent waitOddHandler = new AutoResetEvent(false); 

    static void Main(string[] args)
    {

      Console.WriteLine("Введите верхнюю границу интервала поиска четных и нечетных чисел N : ");
      int N = int.Parse(Console.ReadLine());

      Console.WriteLine("Выведем последовательно - одно четное, другое нечетное число интервала ");

      WriteDataToFile("ALL_NUMBERS.TXT", "\n"); 

      Thread myThread_Odd = new Thread(new ParameterizedThreadStart(OddNum));
      myThread_Odd.Start(N);

      Thread myThread_Even = new Thread(new ParameterizedThreadStart(EvenNum));
      myThread_Even.Start(N);

      // сменим приоритет потока поиска нечетных чисел с Normal на BelowNormal
      myThread_Odd.Priority = ThreadPriority.BelowNormal;

      Console.ReadKey();

    } 

    public static void EvenNum(object N)
    {
      int var_n = (int)N;

      for (int i = 1; i <= var_n; i++) 
      {
        if (i % 2 == 0) 
        {
            waitEvenHandler.WaitOne(); 
            string info_str = i.ToString() + " ";
            Console.Write(info_str);       
            WriteDataToFile("ALL_NUMBERS.TXT", info_str); 
            waitOddHandler.Set(); 
            Thread.Sleep(350); 
        }
      }
    }

    public static void OddNum(object N)
    {
      int var_n = (int)N;

      for (int i = 1; i <= var_n; i++) 
      {
        if (i % 2 != 0) 
        {
          waitOddHandler.WaitOne(); 
          string info_str = i.ToString() + " ";
          Console.Write(info_str);    
          WriteDataToFile("ALL_NUMBERS.TXT", info_str); 
          waitEvenHandler.Set(); 
          Thread.Sleep(700); 
        }
      }
    }

    public static void WriteDataToFile(string file_name, string var_str)
    {
      using (StreamWriter w = new StreamWriter(file_name, true, System.Text.Encoding.Default))
      {
        w.Write(var_str); 
      }
    }
  }
}
