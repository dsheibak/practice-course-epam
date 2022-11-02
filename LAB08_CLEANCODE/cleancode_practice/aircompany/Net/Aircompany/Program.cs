using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Aircompany
{
  class Program
  {
    public static void Main(string[] args)
    {
      Airport airport = new Airport(PlaneRegistry.Planes);
      Airport militaryAirport = new Airport(airport.GetMilitaryPlanes());
      Airport passengerAirport = new Airport(airport.GetPassengersPlanes());
      using (StreamWriter writer = new StreamWriter("ConsoleOutputAircompanyLog.txt"))
      {
        writer.WriteLine(militaryAirport.SortPlanesByMaxFlightDistance().ToString());
        writer.WriteLine(passengerAirport.SortPlanesByMaxSpeed().ToString());
        writer.WriteLine(passengerAirport.GetPassengerPlaneWithMaxPassengersCapacity());
      } 
    }
  }
}
