using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T input);
    }
}
