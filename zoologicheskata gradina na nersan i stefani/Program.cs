using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoologicheskata_gradina_na_nersan_i_stefani
{
    internal class Program
    {
        static void Main(string[] args)
        {
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


    }
}
