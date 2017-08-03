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
        public static Func<IEnumerable<double>, double> FitnessFunction { get; set; }

        public static Chromosome FindBestSolution()
        {
            Chromosome.Length = ChromosomeLength;
            var random = new Random(RandomSeed);
            InitializePopulation(random, PopulationSize);

            var fittest = _population[0];
            fittest.Fitness = FitnessFunction(fittest.Genes);
            foreach (var chromosome in _population)
            {
                chromosome.Fitness = FitnessFunction(chromosome.Genes);
                if (chromosome.Fitness > fittest.Fitness) fittest = chromosome;
            }

            return fittest;
        }

        private static IList<Chromosome> _population;

        private static void InitializePopulation(Random random, int populationSize)
        {
            _population = new List<Chromosome>(populationSize);
            for (var i = 0; i < populationSize; i++)
            {
                var genes = new double[Chromosome.Length];
                for (var g = 0; g < Chromosome.Length; g++)
                    genes[g] = GeneMin + (GeneMax - GeneMin) * random.NextDouble();
                _population.Add(new Chromosome(genes));
            }
        }
    }
}