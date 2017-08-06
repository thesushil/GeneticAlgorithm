using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm
{
    public class Chromosome : IComparable<Chromosome>, IEqualityComparer<Chromosome>
    {
        private static readonly int GeneMin = Constants.GeneMin;
        private static readonly int GeneMax = Constants.GeneMax;
        private static readonly int Length = Constants.ChromosomeLength;

        public Chromosome() {}

        public Chromosome(double[] genes, int generation)
        {
            Genes = genes;
            Generation = generation;
            Fitness = FitnessFunction(genes);
        }
        
        public int Generation { get; set; }
        public double[] Genes { get; }
        public double Fitness { get; set; }
        public double RelativeFitness { get; set; }

        public static Func<IEnumerable<double>, double> FitnessFunction { get; set; }

        public static double CreateRandomGene()
        {
            return (GeneMin + (GeneMax - GeneMin) * Constants.MyRandom.NextDouble());
            //return (int)(GeneMin + (GeneMax - GeneMin) * Constants.MyRandom.NextDouble());
        }

        public static Chromosome CreateRandomChromosome(int generation = 0)
        {
            var genes = new double[Length];
            for (var g = 0; g < Length; g++)
                genes[g] = CreateRandomGene();

            return new Chromosome(genes, generation)
            {
                Fitness = FitnessFunction(genes)
            };
        }

        public override string ToString() => $"[{string.Join(" ", Genes)}]";

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