using System;

namespace GeneticAlgorithm
{
    public static class Constants
    {
        private const int RandomSeed = 297;

        public const float MutationRate = 0.05F; // 5% 

        public static readonly Random MyRandom = new Random(RandomSeed);

        public static int ChromosomeLength { get; set; }

        public static int GeneMin { get; set; }
        public static int GeneMax { get; set; }
    }
}