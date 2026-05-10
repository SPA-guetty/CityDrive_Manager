using System;
using CITYDRIVE_MANAGER.PointOfInterest_Folder;
using CITYDRIVE_MANAGER.Vehicles;

namespace CITYDRIVE_MANAGER
{
    public class Test
    {
        public static void Main()
        {
            Console.WriteLine("===== TEST POINTS OF INTEREST =====\n");
            TestPointsOfInterest();

            Console.WriteLine("\n===== TEST VEHICLES =====\n");
            TestVehicles();

            Console.WriteLine("\n===== TEST TRIP =====\n");
            TestTrip();

            Console.WriteLine("\n===== ALL TESTS COMPLETED =====\n");
        }

        public static void TestPointsOfInterest()
        {
            // Test PointOfInterest base class
            Console.WriteLine("-- Testing PointOfInterest --");
            PointOfInterest poi1 = new PointOfInterest
            {
                Name = "Eiffel Tower",
                Latitude = 48.8584,
                Longitude = 2.2945
            };
            Console.WriteLine("POI 1: " + poi1.ToString());
            Console.WriteLine("Google Maps URL: " + poi1.GetGoogleMapsUrl());

            // Test Campus class
            Console.WriteLine("\n-- Testing Campus --");
            Campus campus = new Campus
            {
                Name = "Paris University",
                Latitude = 48.8566,
                Longitude = 2.3522,
                Capacity = 5000
            };
            Console.WriteLine("Campus: " + campus.ToString());

            // Test HistoricalMonument class
            Console.WriteLine("\n-- Testing HistoricalMonument --");
            HistoricalMonument monument = new HistoricalMonument("Louvre Museum", 48.8606, 2.3352, 1793);
            Console.WriteLine("Monument: " + monument.ToString());

            // Test with constructor
            HistoricalMonument monument2 = new HistoricalMonument("Arc de Triomphe", 48.8738, 2.2950, 1836);
            Console.WriteLine("Monument 2: " + monument2.ToString());
        }

        public static void TestVehicles()
        {
            // Test Car class
            Console.WriteLine("-- Testing Car --");
            Car car = new Car
            {
                Brand = "Toyota",
                Color = "Blue",
                Model = "Corolla",
                CurrentSpeed = 0,
                FuelLevel = 50
            };
            Console.WriteLine("Car: Brand=" + car.Brand + ", Model=" + car.Model + ", Color=" + car.Color);
            Console.WriteLine("Speed: " + car.CurrentSpeed + " km/h, Fuel: " + car.FuelLevel + "L");

            // Test Truck class
            Console.WriteLine("\n-- Testing Truck --");
            Truck truck = new Truck
            {
                Brand = "Volvo",
                Color = "Red",
                Tonnage = 10.5,
                CurrentSpeed = 0,
                FuelLevel = 100
            };
            Console.WriteLine("Truck: Brand=" + truck.Brand + ", Color=" + truck.Color + ", Tonnage=" + truck.Tonnage + "T");
            Console.WriteLine("Speed: " + truck.CurrentSpeed + " km/h, Fuel: " + truck.FuelLevel + "L");

            // Test HybridCar class
            Console.WriteLine("\n-- Testing HybridCar --");
            Hybridcar hybridcar = new Hybridcar
            {
                Brand = "Toyota",
                Color = "Green",
                CurrentSpeed = 0,
                FuelLevel = 40,
                BatteryLevel = 100
            };
            Console.WriteLine("HybridCar: Brand=" + hybridcar.Brand + ", Color=" + hybridcar.Color);
            Console.WriteLine("Speed: " + hybridcar.CurrentSpeed + " km/h, Fuel: " + hybridcar.FuelLevel + "L, Battery: " + hybridcar.BatteryLevel + "%");
        }

        public static void TestTrip()
        {
            // Create points of interest
            PointOfInterest start = new PointOfInterest
            {
                Name = "Paris",
                Latitude = 48.8566,
                Longitude = 2.3522
            };

            PointOfInterest destination = new PointOfInterest
            {
                Name = "Lyon",
                Latitude = 45.7640,
                Longitude = 4.8357
            };

            // Create vehicle
            Car vehicle = new Car
            {
                Brand = "Renault",
                Color = "Black",
                Model = "Scenic",
                CurrentSpeed = 0,
                FuelLevel = 60
            };

            // Create trip
            Trip trip = new Trip
            {
                Vehicle = vehicle,
                Start = start,
                Destination = destination,
                Starttime = DateTime.Now
            };

            Console.WriteLine("Trip Details:");
            Console.WriteLine("Vehicle: " + trip.Vehicle.Brand);
            Console.WriteLine("From: " + trip.Start.Name);
            Console.WriteLine("To: " + trip.Destination.Name);
            Console.WriteLine("Distance: " + trip.GetDistance() + " km");
            Console.WriteLine("Estimated Duration: " + trip.GetDurationInMinutes() + " minutes");
            Console.WriteLine("Start Time: " + Trip.DisplayDateWithoutTime(trip.Starttime));

            // Test date formatting
            Console.WriteLine("\n-- Testing Date Formatting --");
            DateTime testDate = new DateTime(2026, 5, 10, 14, 30, 0);
            string formattedDate = Trip.DisplayDateWithoutTime(testDate);
            Console.WriteLine("Formatted Date: " + formattedDate);

            // Test date parsing
            Console.WriteLine("\n-- Testing Date Parsing --");
            string dateString = "10/05/2026 14:30";
            DateTime parsedDate = Trip.FromStringToDateTime(dateString);
            Console.WriteLine("Parsed Date: " + parsedDate.ToString());
        }
    }
}
