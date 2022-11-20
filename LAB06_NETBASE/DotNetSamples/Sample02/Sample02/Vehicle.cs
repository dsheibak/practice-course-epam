using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample02
{
  public abstract class Vehicle
  {
    private Engine engine;
    private Chassis chassis;
    private Transmission transmission;

    public Vehicle(Engine engine, Chassis chassis, Transmission transmission)
    {
      this.engine = engine;
      this.chassis = chassis;
      this.transmission = transmission;
    }

    public virtual string GetInfo()
    {
      return "ДВИГАТЕЛЬ: мощность двигателя " + engine.Power + ", серийный номер двигателя: " + engine.SerialNumber
        + ", тип двигателя: " + engine.Type + ", мощность: " + engine.Volume + "\n" +
        "ШАССИ: количество колес: " + chassis.NumberWheels + ", номер: " + chassis.Number + ", допустимая нагрузка: " + chassis.PermissibleLoad + "\n"
        + "ТРАНСМИССИЯ: тип: " + transmission.Type + ", количество передач: " + transmission.GearsNumber + ", производитель: " + transmission.Manufacturer;
    }
  }
}
