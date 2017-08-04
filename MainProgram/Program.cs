using System;
using MathEquations;
using GeneticAlgorithm;

namespace MainProgram
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Algorithm.FitnessFunction = Equation1.CalculateFitness;
            Constants.ChromosomeLength = Equation1.VariableCount;

            var bestSolution = GeneticAlgorithm.Algorithm.FindBestSolution();
            Console.WriteLine($"Chromosome: {bestSolution}, Fitness:{bestSolution.Fitness}");


            watch.Stop();
            Console.WriteLine($"Elapsed time in Milliseconds: {watch.ElapsedMilliseconds}");

            Console.ReadLine();
        }
    }
}
