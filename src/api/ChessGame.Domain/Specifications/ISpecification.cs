using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T candidate);
    }
}
