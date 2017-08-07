using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GeneticAlgorithm
{
    public class Algorithm
    {
        public Algorithm(Func<IEnumerable<double>, double> fitnessFunction)
        {
            Chromosome.FitnessFunction = fitnessFunction;
        }

        public Chromosome FindBestSolution()
        {
            InitializePopulation(PopulationSize);
            var fittest = _population.Max();
            UpdateRelativeFitness(fittest.Fitness);

            // Next Generation
            while (_generation++ < MaxGeneration)
            {
                var nextGeneration = new NextGeneration(_generation);
                var children = nextGeneration.Create(_population).ToList();
                
                _population.UnionWith(children);

                fittest = _population.Max();
                UpdateRelativeFitness(fittest.Fitness);

                KillOldAndWeak();

                if (_population.Count > MaxPopulation) LimitPopulation();
            }

            return fittest;
        }

        private void KillOldAndWeak()
        {
            _population.RemoveWhere(c => _generation - c.Generation > OldGeneratioin
                                         && _myRandom.NextDouble() > c.RelativeFitness);
        }

        private void LimitPopulation()
        {
            // sort by RelativeFitness and keep top fittest
            // Adding random selection makes it very slow
            var keepList = _population.OrderByDescending(c => c.RelativeFitness).Take(MaxPopulation);
            _population = new HashSet<Chromosome>(keepList, new Chromosome());
        }

        private void UpdateRelativeFitness(double maxFitness)
        {
            foreach (var chromosome in _population)
            {
                chromosome.RelativeFitness = chromosome.Fitness / maxFitness;
            }
        }

        private void InitializePopulation(int populationSize)
        {
            _population = new HashSet<Chromosome>(new Chromosome());
            for (var i = 0; i < populationSize; i++)
            {
                _population.Add(Chromosome.CreateRandomChromosome(_generation));
            }
        }

        private HashSet<Chromosome> _population;
        private int _generation = 1;
        private readonly Random _myRandom = AlgoParam.MyRandom;
        private const int MaxPopulation = AlgoParam.MaxPopulation;
        private const int PopulationSize = AlgoParam.InitialPopulation;
        private const int MaxGeneration = AlgoParam.MaxGeneration;
        private const int OldGeneratioin = AlgoParam.OldGeneration;
    }
}