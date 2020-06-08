using ChessGame.Domain.ValueObjects.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Services
{
    public static class SpecificationEvaluator
    {
        public static bool And<T>(T candidate, params ISpecification<T>[] specifications)
        {
            return specifications.All(s => s.IsSatisfied(candidate));
        }
    }
}
