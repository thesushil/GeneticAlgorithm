using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GeneticAlgorithm
{
    public static class NextGeneration
    {
        public static IEnumerable<Chromosome> Create(IList<Chromosome> population)
        {
            var parents = SelectParents(population).ToList();

            var children = new Collection<Chromosome>();
            for (var i = 0; i < parents.Count; i++)
            {
                for (var j = i + 1; j < parents.Count; j++)
                {
                    if (Math.Abs(parents[i].Fitness - parents[j].Fitness) < 0.0001) continue;
                    var child = CrossOver(parents[i], parents[j]);
                    Mutate(child);
                    children.Add(child);
                }
            }
            return children;
        }

        private static void Mutate(Chromosome child)
        {
            if (MyRandom.NextDouble() < Constants.MutationRate)
            {
                child.Genes[MyRandom.Next(ChromosomeLength)] = Chromosome.CreateRandomGene();
            }
        }

        private static IEnumerable<Chromosome> SelectParents(IEnumerable<Chromosome> chromosomes)
        {
            var parents = new Collection<Chromosome>();
            foreach (var chromosome in chromosomes)
            {
                if (MyRandom.NextDouble() < chromosome.RelativeFitness)
                    parents.Add(chromosome);
            }
            return parents;
        }

        private static Chromosome CrossOver(Chromosome parent1, Chromosome parent2)
        {
            var crossPoint = MyRandom.Next(ChromosomeLength - 1); // -1 ensures at least 1 gene from parent2
            var newGene = new double[ChromosomeLength];
            var i = 0;
            for (; i <= crossPoint; i++) newGene[i] = parent1.Genes[i];
            for (; i < ChromosomeLength; i++) newGene[i] = parent2.Genes[i];

            return new Chromosome(newGene);
        }

        private static readonly int ChromosomeLength = Constants.ChromosomeLength;
        private static readonly Random MyRandom = Constants.MyRandom;
    }
}