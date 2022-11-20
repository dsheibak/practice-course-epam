using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample03
{
  [Serializable]
  public class Engine
  {
    private int power, volume;
    private string type, serialNumber;
    public int totalEngines = 0;

    public Engine()
    {

    }

    public int Power
    {
      get
      {
        return power;    
      }
      set
      {
        power = value;   
      }
    }

    public int Volume
    {
      get
      {
        return volume;
      }
      set
      {
        volume = value;
      }
    }

    public string Type
    {
      get
      {
        return type;
      }
      set
      {
        type = value;
      }
    }

    public string SerialNumber
    {
      get
      {
        return serialNumber;
      }
      set
      {
        serialNumber = value;
      }
    }

    public string EngineClassInfo()
    {
      return "Class Engine - " + totalEngines + " объектов данного класса создано на данный момент.";
    }

    public Engine(int power, int volume, string type, string serialNumber)
    {
      Power = power;
      Volume = volume;
      Type = type;
      SerialNumber = serialNumber;
      totalEngines++;
    }

    public override string ToString()
    {
      return "Engine: " + Power + " " + Volume + " " + Type + " " + SerialNumber;
    }

  }
}
