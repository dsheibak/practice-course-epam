using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample03
{
  [Serializable]
  public class Transmission
  {
    private int type, gearsNumber;
    private string manufacturer;
    public int totalTransmissions = 0;

    public Transmission()
    {

    }

    public int Type
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

    public int GearsNumber
    {
      get
      {
        return gearsNumber;
      }
      set
      {
        gearsNumber = value;
      }
    }

    public string Manufacturer
    {
      get
      {
        return manufacturer;
      }
      set
      {
        manufacturer = value;
      }
    }

    public string TransmissionClassInfo()
    {
      return "Class Transmission - " + totalTransmissions + " объектов данного класса создано на данный момент.";
    }

    public Transmission(int type, int gearsNumber, string manufacturer)
    {
      Type = type;
      GearsNumber = gearsNumber;
      Manufacturer = manufacturer;
      totalTransmissions++;
    }

    public override string ToString()
    {
      return "Transmission: " + Type + " " + GearsNumber + " " + Manufacturer;
    }

  }
}
