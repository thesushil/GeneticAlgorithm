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
                    var newGenes = CrossOver(parents[i], parents[j]);
                    Mutate(newGenes);
                    children.Add(new Chromosome(newGenes, _generation));
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

        private static Gene[] CrossOver(Chromosome parent1, Chromosome parent2)
        {
            // .Next includes lower limit but excludes upper limit
            // -1 ensures at least 1 gene from every parent
            var crossPoint1 = MyRandom.Next(ChromosomeLength - 1);
            var crossPoint2 = MyRandom.Next(ChromosomeLength - 1);

            var temp = crossPoint1;
            if (crossPoint1 > crossPoint2)
            {
                crossPoint1 = crossPoint2;
                crossPoint2 = temp;
            }

            var newGenes = new Gene[ChromosomeLength];
            var i = 0;
            for (; i <= crossPoint1; i++) newGenes[i] = parent1.Genes[i];
            for (; i <= crossPoint2; i++) newGenes[i] = parent2.Genes[i];
            for (; i < ChromosomeLength; i++) newGenes[i] = parent1.Genes[i];

            return newGenes;
        }

        private static void Mutate(Gene[] genes)
        {
            if (MyRandom.NextDouble() < Constants.MutationRate)
            {
                genes[MyRandom.Next(ChromosomeLength)] = Gene.CreateRandomGene();
                genes[MyRandom.Next(ChromosomeLength)] = Gene.CreateRandomGene();
            }
        }

        private readonly int _generation;

        private static readonly int ChromosomeLength = Constants.ChromosomeLength;
        private static readonly Random MyRandom = Constants.MyRandom;
        private const int MaxParents = Constants.MaxNumOfParents;
    }
}