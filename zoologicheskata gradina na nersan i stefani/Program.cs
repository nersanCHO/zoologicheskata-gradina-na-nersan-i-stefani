using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoologicheskata_gradina_na_nersan_i_stefani
{
    internal class Program
    {
        private const string filePath = "../../animals.txt";

        private static List<Animals> animals = new List<Animals>();
        private static string menuActionChoice;

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            List<Animals> Animals = LoadAnimalssFromFile(filePath);

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Д О Б Р Е   Д О Ш Л И   В   З О О Л О Г И Ч Е С К А Т А   Г Р А Д И Н А");
                Console.WriteLine();
                Console.WriteLine("           \"Г Н Е З Д О Т О   Н А   Т А Р А Н Т У Л И Т Е\"");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Добавяне на ново животно");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("2. Промяна на статуса наличност на животно");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("3. Проверка на наличността и информацията за животното");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("4. Справка за всички животни");
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("5. Изход");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Изберете опция: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddAnimals(Animals);
                        break;
                    case "2":
                        UpdateAnimalsAvailability(Animals);
                        break;
                    case "3":
                        CheckAnimalsInfo(Animals);
                        break;
                    case "4":
                        ListAllAnimalss(Animals);
                        break;
                    case "5":
                        SaveAnimalssToFile(Animals, filePath);
                        Console.WriteLine("           Б Л А Г О Д А Р И М   Ч Е   И З П О Л З В А Х Т Е");
                        Console.WriteLine("                   Н А Ш А Т А   П Р О Г Р А М А!!!");
                        Console.WriteLine("   В С И Ч К О,   К О Е Т О   П Р А В И М   Е   З А Р А Д И   В А С!!!");
                        Console.WriteLine("                 И   С А М О   З А Р А Д И   В А С!!!");
                        Console.WriteLine("           ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("           ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("           ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("           ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("           ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("           ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("           ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("           ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("           ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("Невалиден избор. Опитайте отново.");
                        break;
                }
            }

        }
        static List<Animals> LoadAnimalssFromFile(string path)
        {
            List<Animals> Animals = new List<Animals>();

            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);

                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    Animals.Add(new Animals
                    {
                        AnimalId = parts[0],
                        Species = parts[1],
                        Name = parts[2],
                        Age = int.Parse(parts[3]),
                        Habitat = parts[4],
                        Availability = bool.Parse(parts[5])
                    });
                }
            }

            return Animals;
        }
        static void SaveAnimalssToFile(List<Animals> Animals, string path)
        {
            List<string> lines = Animals.Select(a => $"{a.AnimalId},{a.Species},{a.Name},{a.Age},{a.Habitat},{a.Availability}").ToList();
            File.WriteAllLines(path, lines);
        }

        static void AddAnimals(List<Animals> Animals)
        {
            Console.Write("Въведете ID на животното: ");
            string AnimalsId = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Въведете вид на животното: ");
            string species = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Въведете име на животното: ");
            string name = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Въведете възраст на животното: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Въведете местообитание на животното: ");
            string habitat = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Животното налично ли е за разглеждане? (true/false): ");
            bool availability = bool.Parse(Console.ReadLine());
            Console.WriteLine();

            Animals.Add(new Animals
            {
                AnimalId = AnimalsId,
                Species = species,
                Name = name,
                Age = age,
                Habitat = habitat,
                Availability = availability
            });

            SaveAnimalssToFile(Animals, filePath);
            Console.WriteLine("Животното е добавено успешно.");
            Console.WriteLine();
        }

        static void UpdateAnimalsAvailability(List<Animals> Animals)
        {
            Console.WriteLine();
            Console.Write("Въведете ID на животното: ");
            string AnimalsId = Console.ReadLine();
            Console.WriteLine();

            var Animal = Animals.FirstOrDefault(a => a.AnimalId == AnimalsId);
            if (Animals == null)
            {
                Console.WriteLine();
                Console.WriteLine("Животно с този ID не е намерено.");
                Console.WriteLine();
                return;
            }

            Console.Write("Животното налично ли е за разглеждане? (true/false): ");
            Animal.Availability = bool.Parse(Console.ReadLine());
            Console.WriteLine();

            SaveAnimalssToFile(Animals, filePath);
            Console.WriteLine("Статусът на наличност е променен успешно.");
            Console.WriteLine();
        }
        static void CheckAnimalsInfo(List<Animals> Animals)
        {
            Console.WriteLine();
            Console.Write("Въведете ID на животното: ");
            string AnimalsId = Console.ReadLine();
            Console.WriteLine();

            var Animal = Animals.FirstOrDefault(a => a.AnimalId == AnimalsId);
            if (Animal == null)
            {
                Console.WriteLine();
                Console.WriteLine("Животно с този ID не е намерено.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Вид: {Animal.Species}");
            Console.WriteLine();
            Console.WriteLine($"Име: {Animal.Name}");
            Console.WriteLine();
            Console.WriteLine($"Възраст: {Animal.Age}");
            Console.WriteLine();
            Console.WriteLine($"Местообитание: {Animal.Habitat}");
            Console.WriteLine();
            Console.WriteLine($"Наличност: {Animal.Availability}");
            Console.WriteLine();
        }
        static void ListAllAnimalss(List<Animals> Animals)
        {
            foreach (var Animal in Animals)
            {
                Console.WriteLine();
                Console.WriteLine($"ID: {Animal.AnimalId}");
                Console.WriteLine();
                Console.WriteLine($"Вид:{Animal.Species}");
                Console.WriteLine();
                Console.WriteLine($"Име: {Animal.Name}");
                Console.WriteLine();
                Console.WriteLine($"Възраст: {Animal.Age}");
                Console.WriteLine();
                Console.WriteLine($"Местообитание: {Animal.Habitat}");
                Console.WriteLine();
                Console.WriteLine($"Наличност: {Animal.Availability}");
                Console.WriteLine();
            }
        }


    }
}
