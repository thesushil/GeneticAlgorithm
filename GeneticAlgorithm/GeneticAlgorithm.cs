using System;
using System.Collections.Generic;

namespace GeneticAlgorithm
{
    public static class GeneticAlgorithm
    {
        private const int RandomSeed = 297;
        private const int PopulationSize = 100;
        private const int ChromosomeLength = 4;
        private const int GeneMin = -100, GeneMax = 100; 

        public static Chromosome FindBestSolution()
        {
            Chromosome.Length = ChromosomeLength;
            var random = new Random(RandomSeed);
            InitializePopulation(random, PopulationSize);
            return _population[random.Next(0,PopulationSize-1)];
        }

        private static IList<Chromosome> _population;

        private static void InitializePopulation(Random random, int populationSize)
        {
            _population = new List<Chromosome>(populationSize);
            for (var i = 0; i < populationSize; i++)
            {
                var genes = new int[Chromosome.Length];
                for (var g = 0; g < Chromosome.Length; g++)
                    genes[g] = random.Next(GeneMin, GeneMax);
                _population.Add(new Chromosome(genes));
            }
        }
    }
}