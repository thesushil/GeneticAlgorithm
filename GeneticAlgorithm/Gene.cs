using System;

namespace GeneticAlgorithm
{
    public class Gene
    {
        private Gene(double value)
        {
            Value = value;
        }

        public double Value { get;}

        public static Gene CreateRandomGene()
        {
            // Uncomment below for double genes
            //return new Gene(GeneMin + (GeneMax - GeneMin) * AlgoParam.MyRandom.NextDouble());

            // Uncomment below for Integer genes
            return new Gene(AlgoParam.MyRandom.Next(GeneMin, GeneMax + 1));
            // +1 to make the range inclusive; otherwise the random int is always less than GeneMax
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        private static readonly int GeneMin = AlgoParam.GeneMin;
        private static readonly int GeneMax = AlgoParam.GeneMax;
    }
}