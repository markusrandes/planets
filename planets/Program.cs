using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace planet
{
    class Program
    {
        public class Item
        {
            string name;
            int mass;

            public Item(string _name, int _mass)
            {
                name = _name;
                mass = _mass;
                Console.WriteLine($"Item {name} create");
            }

            public string Name { get { return name; } }
            public int Mass { get { return mass; } }
        }
        static void Main(string[] args)
        {
            planet();
        }

        public static void planet()
        {
            string filePath = @"C:\Users\opilane\samples";
            string fileName = @"planets.txt";

            List<Item> planet = new List<Item>();

            List<string> linesFromFile = File.ReadAllLines(Path.Combine(filePath, fileName)).ToList();

            foreach (string line in linesFromFile)
            {
                string[] tempArray = line.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                Item newItem = new Item(tempArray[0], Int32.Parse(tempArray[1]));
                planet.Add(newItem);

            }

            Console.WriteLine("your planets :");
            int total = 0;
            foreach (Item item in planet)
            {
                Console.WriteLine($"Item: {item.Name}; mass: {item.Mass}");
                total += item.Mass;
            }
            Console.WriteLine($"Your planets total mass is : {total} ");
        }
    }
}