using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgoProblems
{
    public class Equation2 : IProblem<double>
    {
        // e.g. a + 2b + 5c + 4d + 8e + 7f + 13g + 6g = 30

        public int VariableCount => 8;
        public int VariableMin => -100;
        public int VariableMax => 100;

        public double CalculateFitness(IEnumerable<double> variables)
        {
            var eqVar = variables.ToArray();
            var fitness = Math.Abs(eqVar[0] + 2 * eqVar[1]
                + 5 * eqVar[2] + 4 * eqVar[3]
                + 8 * eqVar[4] + 7 * eqVar[5]
                + 13 * eqVar[6] + 6 * eqVar[7]
                - 30);
            return 1.0 / (1 + fitness);
        }
    }
}