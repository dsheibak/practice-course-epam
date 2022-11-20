using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 
using System.Threading;

namespace ConsoleApp2
{
  class Program
  {
    static void Main(string[] args)
    {
      try { 
      Console.WriteLine("Введите верхнюю границу интервала поиска простых чисел N : ");
      int N = int.Parse(Console.ReadLine());

      Thread myThread = new Thread(new ParameterizedThreadStart(PrintSimpleNum)); 
      myThread.Name = "My Simple Numbers Finder"; 
      myThread.Start(N);

      Console.WriteLine("\nИнформация о потоке :");
      Console.WriteLine("ИД потока : {0}", myThread.ManagedThreadId); 
      Console.WriteLine("Имя потока : {0}", myThread.Name);
      Console.WriteLine("Запущен ли поток : {0}", myThread.IsAlive);
      Console.WriteLine("Приоритет потока : {0}", myThread.Priority);
      Console.WriteLine("Статус потока : {0}", myThread.ThreadState);

      Console.WriteLine("\nНажмите любую клавишу для приостановления работы потока");

      Console.ReadKey();
      myThread.Suspend(); 

      Console.WriteLine("\nНажмите любую клавишу для возобновления работы потока");
      Console.ReadKey();
      myThread.Resume();

      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return;
      }
    }

    public static void WriteDataToFile(string file_name, string var_str)
    {
      using (StreamWriter w = new StreamWriter(file_name, true, System.Text.Encoding.Default))
      {
        w.Write(var_str); 
      }
    }

    public static void PrintSimpleNum(object N)
    {
      // метод выводит на консоль и в файл простые числа от 1 до N 

      WriteDataToFile("SIMPLE_NUMBERS.TXT", "\n");
      int var_n = (int)N;

      for (int i = 1; i <= var_n; i++) 
      {

        bool is_simple = true; 
        // чтобы убедиться, простое число или нет, достаточно проверить не делитcя ли число на числа до его половины
        for (int j = 2; j <= (int)(i/2); j++)
        {
          if (i%j == 0) 
          {
            is_simple = false; 
            break;
          }
        }

        if (is_simple)
        {
            string info_str = i.ToString() + " ";
            Console.Write(info_str);   
            WriteDataToFile("SIMPLE_NUMBERS.TXT", info_str); 
            Thread.Sleep(500); 
        }
      }
    }
  }
}
