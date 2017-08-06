using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgoProblems
{
    public class NQueen : IProblem<double>
    {
        public NQueen(int n)
        {
            _n = n;
            _totalAttacks = _n * (_n - 1) / 2.0;
        }

        public int VariableCount => _n;
        public int VariableMax => _n;
        public int VariableMin => 1;

        public double CalculateFitness(IEnumerable<double> variables)
        {
            var positions = variables.Select(v => Convert.ToInt32(v)).ToArray();

            var queenClash = new NQueenClash(positions);
            var attacks = 0;
            attacks += queenClash.CalculateRowAttacks();
            attacks += queenClash.CalculateDiagAttacks();

            return (_totalAttacks - attacks) / _totalAttacks;
        }

        private readonly int _n;
        private readonly double _totalAttacks;
    }
}