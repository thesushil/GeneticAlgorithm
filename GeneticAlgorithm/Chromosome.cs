using System;

namespace GeneticAlgorithm
{
    public class Chromosome : IComparable<Chromosome> 
    {
        private static readonly int GeneMin = Constants.GeneMin;
        private static readonly int GeneMax = Constants.GeneMax;
        private static readonly int Length = Constants.ChromosomeLength;

        public Chromosome(double[] genes)
        {
            Genes = genes;
        }
        
        public int Generation { get; set; }
        public double[] Genes { get; }
        public double Fitness { get; set; }
        public double RelativeFitness { get; set; }

        public static double CreateRandomGene()
        {
            return (GeneMin + (GeneMax - GeneMin) * Constants.MyRandom.NextDouble());
        }

        public static Chromosome CreateRandomChromosome()
        {
            var genes = new double[Length];
            for (var g = 0; g < Length; g++)
                genes[g] = CreateRandomGene();
            return new Chromosome(genes);
        }

        public int CompareTo(Chromosome other)
        {
            if (Fitness < other.Fitness) return -1;
            if (Fitness > other.Fitness) return 1;
            return 0;
        }

        public override string ToString()
        {
            return $"[{string.Join(" ", Genes)}]";
        }
    }
}