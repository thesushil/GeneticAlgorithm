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

        public int CalculateDiag1Attacks()
        {
            var col = 1;
            foreach (var row in _positions)
            {
                if (col++ == row) return 1;
            }
            return 1;
        }

        public int CalculateDiag2Attacks()
        {
            throw new System.NotImplementedException();
        }

        private int CalculateIntSumUpto(int n)
        {
            return n * (n + 1) / 2;
        }

        private readonly int[] _positions;
    }
}