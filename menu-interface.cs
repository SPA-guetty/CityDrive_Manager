using System;

namespace CITYDRIVE_MANAGER
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
                Console.WriteLine("9. Quitter");
                Console.Write("Choix: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                        Console.WriteLine("Option sélectionnée : " + input + ". Fonctionnalité non implémentée.");
                        break;
                    case "9":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez entrer un numéro de 1 à 9.");
                        break;
                }
            }

            Console.WriteLine("Au revoir.");
        }
    }
}
