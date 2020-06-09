using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Specifications.Movements
{
    public class JumperMovementSpecification : ISpecification<PieceMovement>
    {
        public bool IsSatisfied(PieceMovement candidate)
        {
            throw new NotImplementedException();
        }
    }
}
