using System;

namespace GeneticAlgorithm
{
    public class Chromosome : IComparable<Chromosome>
    {
        public Chromosome(double[] genes)
        {
            Genes = genes;
        }

        public static int Length { get; set; }
        public int Generation { get; set; }
        public double[] Genes { get; set; }
        public double Fitness { get; set; }
        public double RelativeFitness { get; set; }

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