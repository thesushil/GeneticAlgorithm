using System;

namespace GeneticAlgorithm
{
    public static class Constants
    {
        private const int RandomSeed = 297;

        public static readonly Random MyRandom = new Random(RandomSeed);

        public static int ChromosomeLength { get; set; }
    }
}