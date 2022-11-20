using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample03
{
  [Serializable]
  public class Scooter : Vehicle
  {
    public string model;
    public Scooter()
    {

    }
    public Scooter(Engine engine, Chassis chassis, Transmission transmission, string model) : base(engine, chassis, transmission)
    {
      this.model = model;
    }

    public new string GetInfo()
    {
      return "Модель: " + model;
    }
  }
}
