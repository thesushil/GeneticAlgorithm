using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm
{
    public class Chromosome : IComparable<Chromosome>, IEqualityComparer<Chromosome>
    {
        private static readonly int Length = Constants.ChromosomeLength;

        public Chromosome() {}

        public Chromosome(Gene[] genes, int generation)
        {
            Genes = Array.AsReadOnly(genes);
            Generation = generation;
            Fitness = FitnessFunction(genes.Select(g => (double) g.Value));
        }

        public int Generation { get; }
        public IList<Gene> Genes { get; }
        public double Fitness { get; }
        public double RelativeFitness { get; set; }

        public static Func<IEnumerable<double>, double> FitnessFunction { get; set; }

        public static Chromosome CreateRandomChromosome(int generation = 0)
        {
            var genes = new Gene[Length];
            for (var g = 0; g < Length; g++)
                genes[g] = Gene.CreateRandomGene();

            return new Chromosome(genes, generation);
        }

        public override string ToString() => $"[{string.Join<Gene>(" ", Genes)}]";

        public int CompareTo(Chromosome other) => Fitness.CompareTo(other.Fitness);

        public bool Equals(Chromosome x, Chromosome y) => x.Genes.SequenceEqual(y.Genes);

        public int GetHashCode(Chromosome chromosome)
        {
            var sum = 0;
            foreach (var gene in chromosome.Genes)
                sum = unchecked (sum + gene.GetHashCode());
            return sum;
        }
    }
}