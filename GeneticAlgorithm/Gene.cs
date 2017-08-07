using System;

namespace GeneticAlgorithm
{
    public class Gene
    {
        private Gene(int value)
        {
            Value = value;
        }

        public int Value { get;}

        public static Gene CreateRandomGene()
        {
            //return (GeneMin + (GeneMax - GeneMin) * Constants.MyRandom.NextDouble());

            return new Gene(Constants.MyRandom.Next(GeneMin, GeneMax + 1));
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

        private static readonly int GeneMin = Constants.GeneMin;
        private static readonly int GeneMax = Constants.GeneMax;
    }
}