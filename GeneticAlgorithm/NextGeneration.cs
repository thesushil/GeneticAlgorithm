using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GeneticAlgorithm
{
    public class NextGeneration
    {
        public NextGeneration(int generation)
        {
            _generation = generation;
        }

        public IEnumerable<Chromosome> Create(IEnumerable<Chromosome> population)
        {
            var parents = SelectParents(population).ToList();

            var children = new Collection<Chromosome>();
            for (var i = 0; i < parents.Count; i++)
            {
                for (var j = i + 1; j < parents.Count; j++)
                {
                    if (Math.Abs(parents[i].Fitness - parents[j].Fitness) < 0.0001) continue;
                    var child = CrossOverAndMutate(parents[i], parents[j]);
                    children.Add(child);
                }
            }
            return children;
        }

        private static IEnumerable<Chromosome> SelectParents(IEnumerable<Chromosome> chromosomes)
        {
            var parents = new Collection<Chromosome>();
            foreach (var chromosome in chromosomes)
            {
                if (MyRandom.NextDouble() < chromosome.RelativeFitness)
                    parents.Add(chromosome);
            }
            return parents.OrderByDescending(c => c.Fitness).Take(MaxParents);
        }

        private Chromosome CrossOverAndMutate(Chromosome parent1, Chromosome parent2)
        {
            var crossPoint = MyRandom.Next(ChromosomeLength - 1); // -1 ensures at least 1 gene from parent2
            var newGenes = new double[ChromosomeLength];
            var i = 0;
            for (; i <= crossPoint; i++) newGenes[i] = parent1.Genes[i];
            for (; i < ChromosomeLength; i++) newGenes[i] = parent2.Genes[i];

            Mutate(newGenes);

            return new Chromosome(newGenes, _generation);
        }

        private static void Mutate(double[] genes)
        {
            if (MyRandom.NextDouble() < Constants.MutationRate)
            {
                genes[MyRandom.Next(ChromosomeLength)] = Chromosome.CreateRandomGene();
                genes[MyRandom.Next(ChromosomeLength)] = Chromosome.CreateRandomGene();
            }
        }

        private readonly int _generation;

        private static readonly int ChromosomeLength = Constants.ChromosomeLength;
        private static readonly Random MyRandom = Constants.MyRandom;
        private const int MaxParents = Constants.MaxNumOfParents;
    }
}