using System;
using MathEquations;
using GeneticAlgorithm;

namespace MainProgram
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Algorithm.FitnessFunction = Equation1.CalculateFitness;
            Algorithm.ChromosomeLength = Equation1.VariableCount;

            var bestSolution = GeneticAlgorithm.Algorithm.FindBestSolution();
            Console.WriteLine($"Chromosome: {bestSolution}, Fitness:{bestSolution.Fitness}");
            Console.ReadLine();
        }
    }
}
