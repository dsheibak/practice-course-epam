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
  [XmlInclude(typeof(Scooter))]
  [XmlInclude(typeof(Bus))]
  [XmlInclude(typeof(Truck))]
  [XmlInclude(typeof(PassengerCar))]
  [XmlInclude(typeof(Engine))]
  [XmlInclude(typeof(Transmission))]
  [XmlInclude(typeof(Chassis))]
  [Serializable]
  public abstract class Vehicle
  {
    public Engine engine;
    public Chassis chassis;
    public Transmission transmission;

    public Vehicle()
    {
      
    }
    public Vehicle(Engine engine, Chassis chassis, Transmission transmission)
    {
      this.engine = engine;
      this.chassis = chassis;
      this.transmission = transmission;
    }

    public virtual string GetInfo()
    {
      return "ДВИГАТЕЛЬ: мощность двигателя " + engine.Power + ", серийный номер двигателя: " + engine.SerialNumber
        + ", тип двигателя: " + engine.Type + ", объем: " + engine.Volume + "\n" +
        "ШАССИ: количество колес: " + chassis.NumberWheels + ", номер: " + chassis.Number + ", допустимая нагрузка: " + chassis.PermissibleLoad + "\n"
        + "ТРАНСМИССИЯ: тип: " + transmission.Type + ", количество передач: " + transmission.GearsNumber + ", производитель: " + transmission.Manufacturer;
    }
  }
}
