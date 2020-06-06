using ChessGame.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects.Specifications.Pieces
{
    public class IsPawnMovementAllowed : ISpecification<PieceMovement>
    {
        public bool IsSatisfied(PieceMovement input)
        {
            if (PositionComparer.FileDistanceAbs(input.From, input.To) == 0)
            {
                int rankDistance = PositionComparer.RankDistance(input.From, input.To);

                if (input.Piece.Color == PieceColor.White
                    && rankDistance < 0 && rankDistance >= (input.Piece.HasMoved ? -1 : -2))
                {
                    return true;
                }
                
                if (input.Piece.Color == PieceColor.Black
                    && rankDistance > 0 && rankDistance <= (input.Piece.HasMoved ? 1 : 2))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
