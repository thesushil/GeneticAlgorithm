using System.Collections.Generic;

namespace GeneticAlgoProblems
{
    public interface IProblem<T>
    {
        int VariableCount { get; }
        int VariableMax { get; }
        int VariableMin { get; }

        double CalculateFitness(IEnumerable<T> variables);
    }
}