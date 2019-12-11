using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AlgorithmJSSP
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            int iterationsCount;
            if(int.TryParse(Console.ReadLine(), out iterationsCount))
                Console.WriteLine("Wrong input.");

            JobShop jobShop = new JobShop(filePath);
        }
    }
}
