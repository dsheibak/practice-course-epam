using System;
using System.IO; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection; 

namespace ConsoleApp1
{
  class Program
  {
    static void Main(string[] args)
    {
      string info_str = ""; 
      var allProcess = Process.GetProcesses();

      foreach (Process proc in allProcess) 
      {
        try // антивирус и система защищают некоторые свои процессы от доступа к их информации - обработаем исключение
        {
          info_str += "\nID процесса : " + proc.Id;
          info_str += " , имя : " + proc.ProcessName;
          info_str += " , приоритет : " + proc.PriorityClass;
          info_str += " , время запуска : " + proc.StartTime.ToString("yy-MM-dd HH:mm:ss");
          if (proc.Responding)
          {
            info_str += " , состояние = Выполняется";
          }
          else
          {
            info_str += " , состояние = Не отвечает";
          }                                               
          info_str += " , использовал процессор (всего времени) : " + proc.TotalProcessorTime.TotalMinutes + " минут";

        }
        catch (Exception e)
        {
          info_str += " - доступ к процессу запрещен - сработала защита!";
        }
      }

      Console.WriteLine(info_str); 
      WriteDataToFile("Processes_INFO.txt", info_str); 

      AppDomain domain = AppDomain.CurrentDomain;

      Console.WriteLine("\nИмя текущего домена : {0}", domain.FriendlyName);
      Console.WriteLine("Базовый каталог : {0}", domain.BaseDirectory);
      Console.WriteLine("Имя приложения : {0}", domain.SetupInformation.ApplicationName); 
      Console.WriteLine("Имя файла конфигурации : {0}", domain.SetupInformation.ConfigurationFile); 
      
      PrintDomainAssemblies(domain);
      
      Console.WriteLine("\nСоздадим новый домен, загрузим туда сборку, выгрузим домен :");

      AppDomain newD = AppDomain.CreateDomain("MyNewDomain");

      PrintDomainAssemblies(newD);
      newD.Load("ConsoleApp1");
      PrintDomainAssemblies(newD);

      AppDomain.Unload(newD);


      Console.ReadKey();
    }

    public static void WriteDataToFile(string file_name, string var_str)
    {
      using (StreamWriter w = new StreamWriter(file_name, false, System.Text.Encoding.Default))
      {
        w.WriteLine(var_str); 
      }
    }

    public static void PrintDomainAssemblies(AppDomain var_domain)
    {
      Assembly[] assemblies = var_domain.GetAssemblies(); 
      Console.WriteLine("\nЗагруженные в домен {0} сборки : ", var_domain.FriendlyName);
      foreach (Assembly asm in assemblies) 
      {
        Console.WriteLine(asm.GetName().Name);
      }
      }
    }
  }
}
