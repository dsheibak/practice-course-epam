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
  class Program
  {
    static void Main(string[] args)
    {
      Engine engine = new Engine(678, 1000, "N5637", "0XVAF");
      Chassis chassis = new Chassis(4, 888, 982);
      Transmission transmission = new Transmission(1, 8, "Lokhid");

      Engine engine2 = new Engine(987, 2341, "AAAA23", "XXXXtG");
      Chassis chassis2 = new Chassis(4, 356, 222);
      Transmission transmission2 = new Transmission(2, 8, "Lokhid");

      Engine engine3 = new Engine(678, 1, "N5637", "0XVAF");
      Chassis chassis3 = new Chassis(4, 674, 754);
      Transmission transmission3 = new Transmission(5, 8, "Lokhid");
      Transmission transmission4 = new Transmission(5, 9, "BMV");

      Vehicle scooter = new Scooter(engine, chassis, transmission, "Scooter Minsk76A");
      Vehicle bus = new Bus(engine2, chassis2, transmission2, "Bus Ikarus24M7");
      Vehicle truck = new Truck(engine3, chassis3, transmission3, "Truck MAZ501");
      Vehicle passengerCar = new PassengerCar(engine, chassis2, transmission4, "Car Range Rover");

      Console.WriteLine(((Scooter)scooter).GetInfo());
      Console.WriteLine(scooter.GetInfo());
      Console.WriteLine();

      Console.WriteLine(((Bus)bus).GetInfo());
      Console.WriteLine(bus.GetInfo());
      Console.WriteLine();

      Console.WriteLine(((Truck)truck).GetInfo());
      Console.WriteLine(truck.GetInfo());
      Console.WriteLine();

      Console.WriteLine(((PassengerCar)passengerCar).GetInfo());
      Console.WriteLine(passengerCar.GetInfo());
      Console.WriteLine();

      List<Vehicle> autoPark = new List<Vehicle>();
      autoPark.Add(scooter);
      autoPark.Add(bus);
      autoPark.Add(truck);
      autoPark.Add(passengerCar);

      XmlSerializer formatter = new XmlSerializer(typeof(List<Vehicle>));
      using (FileStream fs = new FileStream("Autopark.xml", FileMode.OpenOrCreate))
      {
        formatter.Serialize(fs, autoPark);
      }


      IEnumerable<Vehicle> filteringQueryByEngineVolume =
                    from element in autoPark
                    where element.engine.Volume > 1.5
                    select element;
      Console.WriteLine();
      Console.WriteLine("Полная информация о всех транспортных средствах, обьем двигателя которых больше чем 1.5 литров: ");
      foreach (var e in filteringQueryByEngineVolume) Console.WriteLine(e.GetInfo());

      List<Vehicle> autoParkQueryByEngineVolume = new List<Vehicle>();
      foreach (var e in filteringQueryByEngineVolume) autoParkQueryByEngineVolume.Add(e);

      XmlSerializer formatter2 = new XmlSerializer(typeof(List<Vehicle>));
      using (FileStream fs = new FileStream("AutoparkQueryByEngineVolume.xml", FileMode.OpenOrCreate))
      {
        formatter2.Serialize(fs, autoParkQueryByEngineVolume);
      }

      IEnumerable<Vehicle> queryEngineInfoForBusAndTrucks =
                    from element2 in autoPark
                    where element2.GetType().ToString().Equals("Sample03.Bus") || element2.GetType().ToString().Equals("Sample03.Truck")
                    select element2;

      Console.WriteLine();
      Console.WriteLine("Тип двигателя, серийный номер и мощность для всех автобусов и грузовиков: ");

      List<Engine> autoParkQueryEngineInfoForBusAndTrucks = new List<Engine>();
      foreach (var e in queryEngineInfoForBusAndTrucks)
      {
        autoParkQueryEngineInfoForBusAndTrucks.Add(e.engine);
        Console.WriteLine(e.engine);
      }

      XmlSerializer formatter3 = new XmlSerializer(typeof(List<Engine>));
      using (FileStream fs = new FileStream("AutoParkQueryEngineInfoForBusAndTrucks.xml", FileMode.OpenOrCreate))
      {
        formatter3.Serialize(fs, autoParkQueryEngineInfoForBusAndTrucks);
      }

      Console.WriteLine();

      var groupQueryByTransmissionType =
                   from element3 in autoPark
                   group element3 by element3.transmission.Type into models
                   select new {TransmissionType = models.Key};

      foreach (var t in groupQueryByTransmissionType)
      {
        Console.WriteLine(t.TransmissionType.ToString());
      }

      List<Vehicle> vehiclesQuery = new List<Vehicle>();
      foreach (var t in groupQueryByTransmissionType)
      {
        foreach(var a in autoPark)
        {
          if (a.transmission.Type == t.TransmissionType) vehiclesQuery.Add(a);
        }
      }

      XmlSerializer formatter4 = new XmlSerializer(typeof(List<Vehicle>));
      using (FileStream fs = new FileStream("AutoParkQueryByTransmissionType.xml", FileMode.OpenOrCreate))
      {
        formatter4.Serialize(fs, vehiclesQuery);
      }
    }
  }
}
