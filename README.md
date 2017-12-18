# Matt.Math.Stats.Wilson

C# implementation of the Wilson score

![Build status](https://switchigan.visualstudio.com/_apis/public/build/definitions/9e65584e-ff3f-4616-b1ab-5227abae1502/12/badge "Build status")

## NuGet

[```Matt.Math.Stats.Wilson```](https://www.nuget.org/packages/Matt.Math.Stats.Wilson/)

## Overview

Inspired by [https://www.evanmiller.org/how-not-to-sort-by-average-rating.html](https://www.evanmiller.org/how-not-to-sort-by-average-rating.html).

### Similarity to [akamud/wilson-score-csharp](https://github.com/akamud/wilson-score-csharp)

No source code was used from [akamud/wilson-score-csharp](https://github.com/akamud/wilson-score-csharp). I discovered that package after having developed the core of this one, although you'll notice it is used in tests to verify results. As such there are some major differences:

 * `Matt.Math.Stats.Wilson` correctly names the `confidence` parameter.
   * [akamud/wilson-score-csharp](https://github.com/akamud/wilson-score-csharp) uses a `confidence` parameter which is actually the z-score.
   * `Matt.Math.Stats.Wilson` calculates z-score from the given `confidence`.
 * `Matt.Math.Stats.Wilson` correctly only allows unsigned integer parameters.
   * Bernoulli trials are counted discretely and have discrete results.

I would have just forked and PR'd [akamud/wilson-score-csharp](https://github.com/akamud/wilson-score-csharp), but these differences would have called for a major overhaul of that package.