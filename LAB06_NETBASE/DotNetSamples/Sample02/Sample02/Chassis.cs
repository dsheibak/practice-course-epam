using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample02
{
  public class Chassis
  {
    private int numberWheels, number, permissibleLoad;
    public int totalChassis = 0;

    public int NumberWheels
    {
      get
      {
        return numberWheels;
      }
      set
      {
        numberWheels = value;
      }
    }

    public int Number
    {
      get
      {
        return number;
      }
      set
      {
        number = value;
      }
    }

    public int PermissibleLoad
    {
      get
      {
        return permissibleLoad;
      }
      set
      {
        permissibleLoad = value;
      }
    }

    public string EngineClassInfo()
    {
      return "Class Chassis - " + totalChassis + " объектов данного класса создано на данный момент.";
    }

    public Chassis(int numberWheels, int number, int permissibleLoad)
    {
      NumberWheels = numberWheels;
      Number = number;
      PermissibleLoad = permissibleLoad;
      totalChassis++;
    }

    public override string ToString()
    {
      return "Chassis: " + numberWheels + " " + Number + " " + PermissibleLoad;
    }

  }
}
