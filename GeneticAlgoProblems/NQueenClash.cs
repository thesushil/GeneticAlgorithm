using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgoProblems
{
    public class NQueenClash
    {
        public NQueenClash(int[] positions)
        {
            _positions = positions;
        }

        public int CalculateRowAttacks()
        {
            return _positions
                .GroupBy(i => i)
                .Where(g => g.Count() > 1)
                .Sum(group => CalculateIntSumUpto(group.Count() - 1));
        }

        public int CalculateDiagAttacks()
        {
            var attacks = 0;
            for (var i = 0; i < _positions.Length; i++)
            for (var j = i+1; j < _positions.Length; j++)
            {
                if (Math.Abs(i-j) == Math.Abs(_positions[i] - _positions[j])) attacks++;
            }
            return attacks;
        }

        private int CalculateIntSumUpto(int n)
        {
            return n * (n + 1) / 2;
        }

        private readonly int[] _positions;
    }
}