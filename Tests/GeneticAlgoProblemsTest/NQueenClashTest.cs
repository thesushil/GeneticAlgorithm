using System;
using GeneticAlgoProblems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneticAlgoProblemsTest
{
    [TestClass]
    public class NQueenClashTest
    {
        [TestMethod]
        public void CalculateRowAttacks()
        {
            NQueenClash queenClash = null;
            var attacks = 0;

            queenClash = new NQueenClash(new []{1,1,1,1});
            attacks = queenClash.CalculateRowAttacks();
            Assert.AreEqual(6, attacks);

            queenClash = new NQueenClash(new[] { 1, 1, 1, 2, 2, 3 });
            attacks = queenClash.CalculateRowAttacks();
            Assert.AreEqual(4, attacks);

            queenClash = new NQueenClash(new[] { 1, 5, 1, 2, 3, 3 });
            attacks = queenClash.CalculateRowAttacks();
            Assert.AreEqual(2, attacks);

            queenClash = new NQueenClash(new[] { 1, 5, 6, 7, 2, 3, 4 });
            attacks = queenClash.CalculateRowAttacks();
            Assert.AreEqual(0, attacks);
        }

        [TestMethod]
        public void CalculateDiagAttacks()
        {
            NQueenClash queenClash = null;
            var attacks = 0;

            queenClash = new NQueenClash(new[] { 1, 1, 1, 1 });
            attacks = queenClash.CalculateDiagAttacks();
            Assert.AreEqual(0, attacks);

            queenClash = new NQueenClash(new[] { 1, 2, 3, 2, 2, 3 });
            attacks = queenClash.CalculateDiagAttacks();
            Assert.AreEqual(5, attacks);
        }
    }
}
