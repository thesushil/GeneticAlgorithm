using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgoProblems
{
    public class Equation1 : IProblem<double>
    {
        // e.g. a + 2b + 3c + 4d = 30

        public int VariableCount => 4;
        public int VariableMin => -100;
        public int VariableMax => 100;

        public double CalculateFitness(IEnumerable<double> variables)
        {
            var eqVar = variables.ToArray();
            var fitness = Math.Abs(eqVar[0] + 2 * eqVar[1] 
                + 3 * eqVar[2] + 4 * eqVar[3]
                - 30);
            return 1.0/(1 + fitness);
        }
    }
}