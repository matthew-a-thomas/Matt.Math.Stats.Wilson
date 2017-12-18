namespace Tests
{
    using System;
    using MathNet.Numerics.Distributions;
    using Matt.Math.Stats.Wilson;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WilsonScore;

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
                        var myScore = WilsonScore.Calculate(up, total, confidence);
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