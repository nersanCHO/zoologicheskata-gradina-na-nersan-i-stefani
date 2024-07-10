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
        private const string filePath = "../../../../animals.txt";

        private static List<Animals> animals = new List<Animals>();
        private static string menuActionChoice;

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            List<Animals> Animals = LoadAnimalssFromFile(filePath);

            while (true)
            {
                Console.WriteLine("1. Добавяне на ново животно");
                Console.WriteLine("2. Промяна на статуса наличност на животно");
                Console.WriteLine("3. Проверка на наличността и информацията за животното");
                Console.WriteLine("4. Справка за всички животни");
                Console.WriteLine("5. Изход");
                Console.Write("Изберете опция: ");
                string choice = Console.ReadLine();

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

            Console.Write("Въведете вид на животното: ");
            string species = Console.ReadLine();

            Console.Write("Въведете име на животното: ");
            string name = Console.ReadLine();

            Console.Write("Въведете възраст на животното: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Въведете местообитание на животното: ");
            string habitat = Console.ReadLine();

            Console.Write("Животното налично ли е за разглеждане? (true/false): ");
            bool availability = bool.Parse(Console.ReadLine());

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
        }

        static void UpdateAnimalsAvailability(List<Animals> Animals)
        {
            Console.Write("Въведете ID на животното: ");
            string AnimalsId = Console.ReadLine();

            var Animal = Animals.FirstOrDefault(a => a.AnimalId == AnimalsId);
            if (Animals == null)
            {
                Console.WriteLine("Животно с този ID не е намерено.");
                return;
            }

            Console.Write("Животното налично ли е за разглеждане? (true/false): ");
            Animal.Availability = bool.Parse(Console.ReadLine());

            SaveAnimalssToFile(Animals, filePath);
            Console.WriteLine("Статусът на наличност е променен успешно.");
        }
        static void CheckAnimalsInfo(List<Animals> Animals)
        {
            Console.Write("Въведете ID на животното: ");
            string AnimalsId = Console.ReadLine();

            var Animal = Animals.FirstOrDefault(a => a.AnimalId == AnimalsId);
            if (Animals == null)
            {
                Console.WriteLine("Животно с този ID не е намерено.");
                return;
            }

            Console.WriteLine($"Вид: {Animal.Species}");
            Console.WriteLine($"Име: {Animal.Name}");
            Console.WriteLine($"Възраст: {Animal.Age}");
            Console.WriteLine($"Местообитание: {Animal.Habitat}");
            Console.WriteLine($"Наличност: {Animal.Availability}");
        }
        static void ListAllAnimalss(List<Animals> Animals)
        {
            foreach (var Animal in Animals)
            {
                Console.WriteLine($"ID: {Animal.AnimalId}, Вид: {Animal.Species}, Име: {Animal.Name}, Възраст: {Animal.Age}, Местообитание: {Animal.Habitat}, Наличност: {Animal.Availability}");
            }
        }


    }
}
