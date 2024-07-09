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

    }
}
