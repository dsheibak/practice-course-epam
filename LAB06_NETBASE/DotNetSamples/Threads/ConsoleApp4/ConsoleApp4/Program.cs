using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp4
{
  class Program
  {
    static string my_str = "Daria Sheibak";

    static int left_pos = 0; 
    static void Main(string[] args)
    {
      TimerCallback my_tm = new TimerCallback(MoveString);
      Timer timer = new Timer(my_tm, null, 0, 150);
      Console.ReadKey();
    }

    public static void MoveString(object var_obj)
    {
      string str = ""; 
      for (int i = 1; i <= left_pos; i++) str += " "; 
      str += my_str; 
      Console.Clear();
      Console.WriteLine(str);
      left_pos++;  
    }
  }
}
