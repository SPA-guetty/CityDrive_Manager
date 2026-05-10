using System;
using System.Collections.Generic;
using System.Globalization;
using CITYDRIVE_MANAGER.PointOfInterest_Folder;
using CITYDRIVE_MANAGER.Vehicles;

namespace CITYDRIVE_MANAGER
{
    public class Program
    {
        private static readonly List<PointOfInterest> Places = new List<PointOfInterest>();
        private static readonly List<Vehicle> Vehicles = new List<Vehicle>();
        private static readonly List<Trip> Trips = new List<Trip>();

        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("CityDrive Manager - Menu interactif");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("1. Ajouter un point d’intérêt");
                Console.WriteLine("2. Ajouter un véhicule");
                Console.WriteLine("3. Afficher les véhicules");
                Console.WriteLine("4. Afficher les lieux");
                Console.WriteLine("5. Calculer une distance");
                Console.WriteLine("6. Simuler une accélération/freinage");
                Console.WriteLine("7. Créer un trajet");
                Console.WriteLine("8. Afficher les trajets");
                Console.WriteLine("9. Faire le plein");
                Console.WriteLine("10. Quitter");
                Console.Write("Choix: ");

                string input = Console.ReadLine() ?? "";
                Console.WriteLine();

                switch (input)
                {
                    case "1": AddPointOfInterest(); break;
                    case "2": AddVehicle(); break;
                    case "3": ShowVehicles(); break;
                    case "4": ShowPlaces(); break;
                    case "5": CalculateDistance(); break;
                    case "6": SimulateVehicle(); break;
                    case "7": CreateTrip(); break;
                    case "8": ShowTrips(); break;
                    case "9": ManageEnergy(); break;
                    case "10": exit = true; break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez entrer un numéro de 1 à 9.");
                        break;
                }
            }

            Console.WriteLine("Merci d'avoir utilisé Citydrive Manager.");
        }

        private static void AddPointOfInterest()
        {            
            Console.Clear();
            Console.WriteLine("Ajouter un point d’intérêt");
            Console.Write("Nom: ");
            string name = Console.ReadLine() ?? "";
            name = name.Trim().ToUpper();
            double latitude = ReadDouble("Latitude: ");
            double longitude = ReadDouble("Longitude: ");
            bool isvalid = false;
            PointOfInterest place = new PointOfInterest();
            while (!isvalid)
            {
                Console.WriteLine("Type de lieu: \n 1) Classique \n 2) Campus \n 3) Monument historique");
                Console.Write("Choix: ");
                string typeChoice = Console.ReadLine() ?? "";

                switch (typeChoice)
                {
                    case "1":
                        place = new PointOfInterest
                        {
                            Name = name,
                            Latitude = latitude,
                            Longitude = longitude
                        };
                        isvalid = true;
                        break;
                    case "2":
                        var campus = new Campus();
                        campus.Name = name;
                        campus.Latitude = latitude;
                        campus.Longitude = longitude;
                        campus.Capacity = ReadInt("Capacité (nombre d’étudiants): ");
                        place = campus;
                        isvalid = true;
                        break;
                    case "3":
                        var monument = new HistoricalMonument();
                        monument.Name = name;
                        monument.Latitude = latitude;
                        monument.Longitude = longitude;
                        monument.BuildYear = ReadInt("Année de construction: ");
                        place = monument;
                        isvalid = true;
                        break;
                    default:
                        Console.WriteLine("Erreur : Veuillez entrer un chiffre entre 1 et 3.");
                        break;
                }
            }

            // Vérifier les doublons
            bool duplicate = false;
            foreach (var p in Places)
            {
                if (p.Name == place.Name)
                {
                    duplicate = true;
                    break;
                }
            }
            
            if (duplicate)
            {
                Console.WriteLine("Erreur : Un lieu avec ce nom existe déjà.");
            }
            else
            {
                Places.Add(place);
                Console.WriteLine("Point d'intérêt ajouté : " + place);
            }
        }

        private static void AddVehicle()
        {
            Console.Clear();
            Console.WriteLine("Ajouter un véhicule");
            Console.Write("Marque: ");
            string brand = Console.ReadLine() ?? "";
            Console.Write("Couleur: ");
            string color = Console.ReadLine() ?? "";

            brand = brand.Trim().ToUpper();
            color = color.Trim().ToUpper();

            Vehicle vehicle = null;

            bool isvalid = false;

            while (!isvalid)
            {
                Console.WriteLine("Type de véhicule: \n 1) Voiture \n 2) Camion \n 3) Hybride");
                Console.Write("Choix: ");
                string typeChoice = Console.ReadLine() ?? "";

                switch (typeChoice)
                {
                    case "1":
                        var car = new Car();
                        car.Brand = brand;
                        car.Color = color;
                        car.Model = ReadString("Modèle: ");
                        car.CurrentSpeed = 0;
                        car.FuelLevel = ReadDouble("Niveau de carburant (L): ");
                        vehicle = car;
                        isvalid = true;
                        break;
                    case "2":
                        var truck = new Truck();
                        truck.Brand = brand;
                        truck.Color = color;
                        truck.Tonnage = ReadDouble("Tonnage: ");
                        truck.CurrentSpeed = 0;
                        truck.FuelLevel = ReadDouble("Niveau de carburant (L): ");
                        vehicle = truck;
                        isvalid = true;
                        break;
                    case "3":
                        var hybrid = new Hybridcar();
                        hybrid.Brand = brand;
                        hybrid.Color = color;
                        hybrid.CurrentSpeed = 0;
                        hybrid.FuelLevel = ReadDouble("Niveau de carburant (L): ");
                        hybrid.BatteryLevel = ReadDouble("Niveau de batterie (%): ");
                        vehicle = hybrid;
                        isvalid = true;
                        break;
                    default:
                        Console.WriteLine("Type invalide.");
                        break;
                }
            }

            Vehicles.Add(vehicle);
            Console.WriteLine("Véhicule ajouté : " + vehicle);
            System.Threading.Thread.Sleep(1500);
        }

        private static void ShowVehicles()
        {
            Console.Clear();
            Console.WriteLine("Véhicules enregistrés :");
            if (Vehicles.Count == 0)
            {
                Console.WriteLine("Aucun véhicule disponible.");
                return;
            }

            for (int i = 0; i < Vehicles.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + Vehicles[i]);
            }
        }

        private static void ShowPlaces()
        {
            Console.Clear();
            Console.WriteLine("Lieux enregistrés :");
            if (Places.Count == 0)
            {
                Console.WriteLine("Aucun lieu disponible.");
                return;
            }

            for (int i = 0; i < Places.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + Places[i]);
            }
        }

        private static void CalculateDistance()
        {
            Console.Clear();
            Console.WriteLine("Calculer une distance");
            if (Places.Count < 2)
            {
                Console.WriteLine("Il faut au moins deux lieux pour calculer une distance.");
                return;
            }

            ShowPlaces();
            int firstIndex = ReadIndex("Choisir le premier lieu (numéro): ", Places.Count);
            int secondIndex = ReadIndex("Choisir le second lieu (numéro): ", Places.Count);
            if (firstIndex == secondIndex)
            {
                Console.WriteLine("Les deux lieux doivent être différents.");
                return;
            }

            var place1 = Places[firstIndex - 1];
            var place2 = Places[secondIndex - 1];
            double distance = place1.GetDistance(place2);
            Console.WriteLine($"Distance entre {place1.Name} et {place2.Name} : {distance} km");
            System.Threading.Thread.Sleep(1500);
        }

        private static void SimulateVehicle()
        {
            Console.Clear();
            Console.WriteLine("Simuler une accélération / freinage");
            if (Vehicles.Count == 0)
            {
                Console.WriteLine("Aucun véhicule disponible.");
                return;
            }
            
            ShowVehicles();
            int index = ReadIndex("Choisir un véhicule (numéro): ", Vehicles.Count);
            var vehicle = Vehicles[index - 1];
            
            bool isvalid = false;
            while (!isvalid)
            {
                Console.WriteLine("1. Accélérer (+10 km/h)");
                Console.WriteLine("2. Freiner (-10 km/h)");
                Console.WriteLine("3. Régler la vitesse");
                Console.Write("Choix: ");
                string choice = Console.ReadLine() ?? "";
            
                switch (choice)
                {
                    case "1":
                        vehicle.Accelerate();
                        Console.WriteLine(vehicle + " accélère.");
                        Console.WriteLine("Vitesse actuelle: " + vehicle.CurrentSpeed + " km/h");
                        isvalid = true;
                        System.Threading.Thread.Sleep(1500);
                        break;
                    case "2":
                        vehicle.Brake();
                        Console.WriteLine(vehicle + " freine.");
                        Console.WriteLine("Vitesse actuelle: " + vehicle.CurrentSpeed + " km/h");
                        isvalid = true;
                        System.Threading.Thread.Sleep(1500);
                        break;
                    case "3":
                        double speed = ReadDouble("Nouvelle vitesse (km/h): ");
                        vehicle.CurrentSpeed = speed;
                        Console.WriteLine(vehicle + " passe à " + speed + " km/h.");
                        isvalid = true;
                        System.Threading.Thread.Sleep(1500);
                        break;
                    default:
                        Console.WriteLine("Action invalide.");
                        break;
                }
            }
        }

        private static void CreateTrip()
        {
            Console.Clear();
            Console.WriteLine("Créer un trajet");
            if (Vehicles.Count == 0)
            {
                Console.WriteLine("Ajoutez d’abord un véhicule.");
                return;
            }
            if (Places.Count < 2)
            {
                Console.WriteLine("Ajoutez au moins deux lieux.");
                return;
            }

            ShowVehicles();
            int vehicleIndex = ReadIndex("Choisir un véhicule (numéro): ", Vehicles.Count);
            ShowPlaces();
            int startIndex = ReadIndex("Choisir le lieu de départ (numéro): ", Places.Count);
            int endIndex = ReadIndex("Choisir le lieu d’arrivée (numéro): ", Places.Count);
            if (startIndex == endIndex)
            {
                Console.WriteLine("Le départ et l’arrivée doivent être différents.");
                return;
            }

            Console.Write("Nom du trajet: ");
            string tripName = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(tripName))
            {
                tripName = "Trajet " + (Trips.Count + 1);
            }

            var trip = new Trip
            {
                Name = tripName,
                Vehicle = Vehicles[vehicleIndex - 1],
                Start = Places[startIndex - 1],
                Destination = Places[endIndex - 1],
                Starttime = DateTime.Now
            };
            Trips.Add(trip);
            Console.WriteLine("Trajet créé : " + trip);
            System.Threading.Thread.Sleep(1500);
        }

        private static void ShowTrips()
        {
            Console.Clear();
            Console.WriteLine("Trajets enregistrés :");
            if (Trips.Count == 0)
            {
                Console.WriteLine("Aucun trajet disponible.");
                return;
            }

            for (int i = 0; i < Trips.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + Trips[i]);
            }
        }

        private static void ManageEnergy()
        {
            Console.Clear();
            Console.WriteLine("--- GESTION DE L'ÉNERGIE ---");
            if (Vehicles.Count == 0) { Console.WriteLine("Aucun véhicule."); return; }

            ShowVehicles();
            int index = ReadIndex("Choisir un véhicule: ", Vehicles.Count);
            var vehicle = Vehicles[index - 1];

            bool acted = false;

            // thermique
            if (vehicle is IThermalCar thermal)
            {
                double amount = ReadDouble($"Carburant actuel : {thermal.FuelLevel}L. Quantité à ajouter : ");
                
                if (amount < 0)
                {
                    Console.WriteLine("Erreur : Vous ne pouvez pas retirer de carburant !");
                }
                else
                {
                    thermal.Refuel(amount);
                    Console.WriteLine($"Succès : Nouveau niveau de carburant : {thermal.FuelLevel}L");
                }
                acted = true;
            }

            // électrique
            if (vehicle is IElectricCar electric)
            {
                double amount = ReadDouble($"Batterie actuelle : {electric.BatteryLevel}%. % à ajouter : ");
                
                if (amount < 0)
                {
                    Console.WriteLine("Erreur : Impossible de décharger la batterie via ce menu.");
                }
                else if (electric.BatteryLevel + amount > 100)
                {
                    double needed = 100 - electric.BatteryLevel;
                    Console.WriteLine($"Alerte : La batterie ne peut pas dépasser 100%. Ajout limité à {needed}%.");
                    electric.Recharge(needed);
                }
                else
                {
                    electric.Recharge(amount);
                    Console.WriteLine($"Succès : Nouveau niveau de batterie : {electric.BatteryLevel}%");
                }
                acted = true;
            }

            if (!acted) Console.WriteLine("Ce véhicule n'est ni thermique, ni électrique.");
            
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();
        }

        private static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (double.TryParse(input, CultureInfo.InvariantCulture, out double result))
                {
                    return result;
                }
                Console.WriteLine("Valeur invalide, réessayez.");
            }
        }

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                Console.WriteLine("Valeur invalide, réessayez.");
            }
        }

        private static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }

        private static int ReadIndex(string prompt, int max)
        {
            while (true)
            {
                int value = ReadInt(prompt);
                if (value >= 1 && value <= max)
                {
                    return value;
                }
                Console.WriteLine("Choix invalide. Entrez un numéro entre 1 et " + max + ".");
            }
        }
    }
}
