namespace GeneticAlgorithm
{
    public class Chromosome
    {
        public Chromosome(int[] genes)
        {
            Genes = genes;
        }

        public static int Length { get; set; }
        public int[] Genes { get; set; }
        public int Fitness { get; set; }

        public override string ToString()
        {
            return $"[{string.Join(" ", Genes)}]";
        }
    }
}