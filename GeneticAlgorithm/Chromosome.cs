namespace GeneticAlgorithm
{
    public class Chromosome
    {
        public Chromosome(double[] genes)
        {
            Genes = genes;
        }

        public static int Length { get; set; }
        public double[] Genes { get; set; }
        public double Fitness { get; set; }

        public override string ToString()
        {
            return $"[{string.Join(" ", Genes)}]";
        }
    }
}