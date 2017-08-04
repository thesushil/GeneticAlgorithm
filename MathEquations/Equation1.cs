using System;
using System.Collections.Generic;
using System.Linq;

namespace MathEquations
{
    public static class Equation1
    {
        // e.g. a + 2b + 3c + 4d = 30

        public const int VariableCount = 8;

        public static double CalculateFitness(IEnumerable<double> variables)
        {
            var eqVar = variables.ToArray();
            var fitness = Math.Abs(
                eqVar[0] + 2 * eqVar[1] 
                + 5 * eqVar[2] + 4 * eqVar[3]
                + 8 * eqVar[4] + 7 * eqVar[5]
                + 13 * eqVar[6] + 6 * eqVar[7]
                - 30);
            return 1.0/(1 + fitness);
        }
    }
}