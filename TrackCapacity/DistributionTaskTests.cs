using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnitLite;

namespace DistributionTask
{
    [TestFixture]
    internal class DistributionTaskTests
    {
        [TestCase(0, new int[] {})]
        [TestCase(40, new int[] {40})]
        [TestCase(5, new int[] { 5 })]
        [TestCase(241, new int[] { 35, 35, 35, 34, 34, 34, 34 })]
        [TestCase(1, new int[] { 1 })]
        [TestCase(39, new int[] { 39 })]
        [TestCase(84, new int[] { 28, 28, 28 })]
        [TestCase(48, new int[] { 24, 24 })]
        [TestCase(85, new int[] { 29, 28, 28 })]
        public static void Test(int input, int[] expectedResult)
        {
            var actualResult = DistributionTask.MakeOptimalDistribution(input, 40);
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            for (int i = 0; i < expectedResult.Length; ++i)
                Assert.AreEqual(expectedResult[i], actualResult[i]);
        }
    }
}
