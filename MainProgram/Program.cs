using System;
using GeneticAlgoProblems;
using GeneticAlgorithm;

namespace MainProgram
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var problem = new NQueen(15);
            //var problem = new Equation2();

            AlgoParam.ChromosomeLength = problem.VariableCount;
            AlgoParam.GeneMin = problem.VariableMin;
            AlgoParam.GeneMax = problem.VariableMax;

            var algo = new Algorithm(problem.CalculateFitness);

            var bestSolution = algo.FindBestSolution();
            Console.WriteLine($"Chromosome: {bestSolution}, Fitness:{bestSolution.Fitness}");

            watch.Stop();
            Console.WriteLine($"Elapsed time in Milliseconds: {watch.ElapsedMilliseconds}");

            Console.ReadLine();
        }
    }
}
