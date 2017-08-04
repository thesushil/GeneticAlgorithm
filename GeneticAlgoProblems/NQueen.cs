using System.Collections.Generic;

namespace GeneticAlgoProblems
{
    public class NQueen : IProblem<int>
    {
        public int VariableCount => 8;
        public int VariableMax => 8;
        public int VariableMin => 1;

        public double CalculateFitness(IEnumerable<int> variables)
        {
            throw new System.NotImplementedException();
        }
    }
}