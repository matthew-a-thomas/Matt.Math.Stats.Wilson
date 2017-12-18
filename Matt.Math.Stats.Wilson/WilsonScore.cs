namespace Matt.Math.Stats.Wilson
{
    using System;
    using MathNet.Numerics.Distributions;

    public static class WilsonScore
    {
        /// <summary>
        /// Computes the lower bound of the Wilson score interval, which estimates the "actual" score of Bernoulli
        /// tests, were they to continue forever.
        /// </summary>
        /// <param name="numberOfPositiveScores">The number of successful Bernoulli tests.</param>
        /// <param name="totalScores">The total number of Bernoulli tests.</param>
        /// <param name="confidence">Desired confidence (0-1); higher confidence results in lower score.</param>
        /// <remarks>
        /// https://www.evanmiller.org/how-not-to-sort-by-average-rating.html
        /// https://en.wikipedia.org/wiki/Binomial_proportion_confidence_interval#Wilson_score_interval
        /// </remarks>
        public static double Calculate(
            uint numberOfPositiveScores,
            uint totalScores,
            double confidence)
        {
            if (totalScores == 0)
                return 0;
            
            var z = Normal.InvCDF(
                mean: 0,
                stddev: 1,
                p: 1 - (1 - confidence) / 2);
            var zSquared = z * z;
            
            var pHat = 1.0 * numberOfPositiveScores / totalScores;
            
            var range =
                z
                * Math.Sqrt(
                    pHat
                    * (1 - pHat)
                    / totalScores
                    
                    + zSquared
                    / (4 * totalScores * totalScores)
                )
                / (1 + zSquared / totalScores);
            
            var center =
                (pHat + (zSquared / (2 * totalScores)))
                / (1 + zSquared / totalScores);
            
            var result = center - range;
            
            return result;
        }
    }
}