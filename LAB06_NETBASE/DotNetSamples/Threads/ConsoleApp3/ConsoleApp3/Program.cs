using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 
using System.Threading;

namespace ConsoleApp3
{
  class Program
  {
    // объект событие, которое при срабатывании автоматически сбрасывается в несигнальное состояние
    static AutoResetEvent waitHandler = new AutoResetEvent(false); 

    static void Main(string[] args)
    {
      Console.WriteLine("Введите верхнюю границу интервала поиска четных и нечетных чисел N : ");
      int N = int.Parse(Console.ReadLine());

      Console.WriteLine("Выведем сперва четные, а затем нечетные числа интервала ");

      WriteDataToFile("ALL_NUMBERS.TXT", "\n"); 

      // создаем и стартуем новый поток - поиск нечетных чисел
      Thread myThread_Odd = new Thread(new ParameterizedThreadStart(OddNum));
      myThread_Odd.Start(N);

      // создаем и стартуем новый поток - поиск четных чисел
      Thread myThread_Even = new Thread(new ParameterizedThreadStart(EvenNum));
      myThread_Even.Start(N);

      // сменим приоритет потока поиска нечетных чисел с Normal на BelowNormal
      myThread_Odd.Priority = ThreadPriority.BelowNormal;

      Console.ReadKey();

    }

    public static void WriteDataToFile(string file_name, string var_str)
    {
      using (StreamWriter w = new StreamWriter(file_name, true, System.Text.Encoding.Default))
      {
        w.Write(var_str); 
      }
    }

    public static void EvenNum(object N)
    {
      int var_n = (int)N;

      for (int i = 1; i <= var_n; i++) 
      {
          if (i % 2 == 0) 
          {
              string info_str = i.ToString() + " ";
              Console.Write(info_str);   
              WriteDataToFile("ALL_NUMBERS.TXT", info_str); 
              Thread.Sleep(350); 
          }
      }

      waitHandler.Set(); 
    }

    public static void OddNum(object N)
    {
      waitHandler.WaitOne(); 

      int var_n = (int)N;
      for (int i = 1; i <= var_n; i++) 
      {
          if (i % 2 != 0) 
          {
              string info_str = i.ToString() + " ";
              Console.Write(info_str); 
              WriteDataToFile("ALL_NUMBERS.TXT", info_str); 
              Thread.Sleep(700); 
          }

       }
    }

    }
  }
