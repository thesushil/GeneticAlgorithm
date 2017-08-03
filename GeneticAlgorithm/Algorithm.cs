using System;
using System.Collections.Generic;

namespace GeneticAlgorithm
{
    public static class Algorithm
    {
        private const int RandomSeed = 297;
        private const int PopulationSize = 10000;
        private const int GeneMin = -100, GeneMax = 100;

        public static int ChromosomeLength { get; set; }
        public static Func<IEnumerable<int>, int> FitnessFunction { get; set; }

        public static Chromosome FindBestSolution()
        {
            Chromosome.Length = ChromosomeLength;
            var random = new Random(RandomSeed);
            InitializePopulation(random, PopulationSize);

            var bestChromosome = _population[0];
            foreach (var chromosome in _population)
            {
                chromosome.Fitness = FitnessFunction(chromosome.Genes);
                if (chromosome.Fitness < bestChromosome.Fitness) bestChromosome = chromosome;
            }

            return bestChromosome;
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