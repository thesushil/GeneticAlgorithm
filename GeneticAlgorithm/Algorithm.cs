using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GeneticAlgorithm
{
    public static class Algorithm
    {
        private const int PopulationSize = 100;
        private const int GeneMin = -100, GeneMax = 100;
        private const int MaxGeneration = 100;

        public static Func<IEnumerable<double>, double> FitnessFunction { get; set; }

        public static Chromosome FindBestSolution()
        {
            Chromosome.Length = Constants.ChromosomeLength;
            InitializePopulation(PopulationSize);
            UpdateFitnessAndGeneration(_population);
            var fittest = _population.Max();
            UpdateRelativeFitness(_population, fittest.Fitness);

            // Next Generation
            while (_generation++ < MaxGeneration)
            {
                var children = NextGeneration.Create(_population).ToList();
                UpdateFitnessAndGeneration(children);
                
                _population.AddRange(children);

                fittest = _population.Max();
                UpdateRelativeFitness(_population, fittest.Fitness);

                KillOld(_population);
            }

            return fittest;
        }

        private static void KillOld(List<Chromosome> population)
        {
            population.RemoveAll(c => _generation - c.Generation > 3 && MyRandom.NextDouble() > 0.5);
        }

        private static void UpdateRelativeFitness(IEnumerable<Chromosome> chromosomes, double maxFitness)
        {
            foreach (var chromosome in chromosomes)
            {
                chromosome.RelativeFitness = chromosome.Fitness / maxFitness;
            }
        }

        private static void UpdateFitnessAndGeneration(IList<Chromosome> chromosomes)
        {
            foreach (var chromosome in chromosomes)
            {
                chromosome.Fitness = FitnessFunction(chromosome.Genes);
                chromosome.Generation = _generation;
            }
        }

        private static void InitializePopulation(int populationSize)
        {
            _population = new List<Chromosome>(populationSize);
            for (var i = 0; i < populationSize; i++)
            {
                var genes = new double[Chromosome.Length];
                for (var g = 0; g < Chromosome.Length; g++)
                    genes[g] = GeneMin + (GeneMax - GeneMin) * MyRandom.NextDouble();
                _population.Add(new Chromosome(genes));
            }
        }

        private static List<Chromosome> _population; // Using List as it supports AddRange
        private static int _generation = 1;
        private static readonly Random MyRandom = Constants.MyRandom;
    }
}