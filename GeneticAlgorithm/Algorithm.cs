using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GeneticAlgorithm
{
    public class Algorithm
    {
        private const int PopulationSize = 10;
        private const int MaxGeneration = 100;

        public Func<IEnumerable<double>, double> FitnessFunction { get; set; }

        public Chromosome FindBestSolution()
        {
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

                //KillOld(_population);
            }

            return fittest;
        }

        private void KillOld(List<Chromosome> population)
        {
            population.RemoveAll(c => _generation - c.Generation > 3 && _myRandom.NextDouble() > 0.5);
        }

        private void UpdateRelativeFitness(IEnumerable<Chromosome> chromosomes, double maxFitness)
        {
            foreach (var chromosome in chromosomes)
            {
                chromosome.RelativeFitness = chromosome.Fitness / maxFitness;
            }
        }

        private void UpdateFitnessAndGeneration(IList<Chromosome> chromosomes)
        {
            foreach (var chromosome in chromosomes)
            {
                chromosome.Fitness = FitnessFunction(chromosome.Genes);
                chromosome.Generation = _generation;
            }
        }

        private void InitializePopulation(int populationSize)
        {
            _population = new List<Chromosome>(populationSize);
            for (var i = 0; i < populationSize; i++)
            {                
                _population.Add(Chromosome.CreateRandomChromosome());
            }
        }

        private List<Chromosome> _population; // Using List as it supports AddRange
        private int _generation = 1;
        private readonly Random _myRandom = Constants.MyRandom;
    }
}