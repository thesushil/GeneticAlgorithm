using System;

namespace MainProgram
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var bestSolution = GeneticAlgorithm.GeneticAlgorithm.FindBestSolution();
            Console.WriteLine($"Chromosome: {bestSolution}, Fitness:{bestSolution.Fitness}");
            Console.ReadLine();
        }
    }
}
