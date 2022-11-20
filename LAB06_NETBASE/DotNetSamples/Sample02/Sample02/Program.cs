using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample02
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

      Engine engine3 = new Engine(678, 1000, "N5637", "0XVAF");
      Chassis chassis3 = new Chassis(4, 674, 754);
      Transmission transmission3 = new Transmission(1, 8, "Lokhid");

      Vehicle scooter = new Scooter(engine, chassis, transmission, "Scooter Minsk76A");
      Vehicle bus = new Bus(engine2, chassis2, transmission2, "Bus Ikarus24M7");
      Vehicle truck = new Truck(engine3, chassis3, transmission3, "Truck MAZ501");
      Vehicle passengerCar = new PassengerCar(engine, chassis2, transmission3, "Car Range Rover");

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
    }
  }
}
