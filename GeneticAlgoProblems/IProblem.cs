using System.Collections.Generic;

namespace GeneticAlgoProblems
{
    public interface IProblem<T>
    {
        int VariableCount { get; }
        int VariableMax { get; }
        int VariableMin { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variables"></param>
        /// <returns>Must return the fitness value between 0 and 1 - 0 is the least fit wheras 1 is the solution</returns>
        double CalculateFitness(IEnumerable<T> variables);
    }
}