using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgoProblems
{
    public class NQueen : IProblem<double>
    {
        private const int N = 8;
        private const double TotalAttacks = N * (N - 1) / 2.0;

        public int VariableCount => N;
        public int VariableMax => N;
        public int VariableMin => 1;

        public double CalculateFitness(IEnumerable<double> variables)
        {
            var positions = variables.Select(v => Convert.ToInt32(v)).ToArray();

            var queenClash = new NQueenClash(positions);
            var rowAttacks = queenClash.CalculateRowAttacks();
            var diag1Attacks = queenClash.CalculateDiag1Attacks();
            var diag2Attacks = queenClash.CalculateDiag2Attacks();

            var attacks = rowAttacks + diag1Attacks + diag2Attacks;

            return (TotalAttacks - attacks) / TotalAttacks;
        }
    }
}