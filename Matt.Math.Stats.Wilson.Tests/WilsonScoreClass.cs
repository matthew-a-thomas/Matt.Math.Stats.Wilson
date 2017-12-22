namespace Matt.Math.Stats.Wilson.Tests
{
    using System;
    using global::WilsonScore;
    using MathNet.Numerics.Distributions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Wilson;

    [TestClass]
    public class WilsonScoreClass
    {
        [TestClass]
        public class CalculateMethod
        {
            [TestMethod]
            public void MatchesAnotherImplementation()
            {
                for (var confidence = 0.01; confidence <= 0.99; confidence += 0.01)
                {
                    var z = Normal.InvCDF(
                        mean: 0,
                        stddev: 1,
                        p: 1 - (1 - confidence) / 2);
                
                    for (uint total = 1; total < 100; ++total)
                    for (uint up = 0; up <= total; ++up)
                    {
                        var myScore = WilsonScore.CalculateWithZScore(up, total, z);
                        var theirScore = Wilson.Score(up, total, z);
                        var difference = Math.Abs(theirScore - myScore);
                        Assert.IsTrue(
                            difference <= 1E-15,
                            $"Difference was {difference}: my score: {myScore}; their score: {theirScore}; up/total: {up}/{total}; confidence: {confidence}");
                    }
                }
            }
        }
    }
}