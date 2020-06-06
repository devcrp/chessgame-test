using ChessGame.Domain.ValueObjects.Specifications.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects.Specifications
{
    public class IsMovementAllowed : ISpecification<PieceMovement>
    {
        public bool IsSatisfied(PieceMovement input)
        {
            ISpecification<PieceMovement> pieceSpecification = ResolveSpecification(input.Piece.Type);
            return pieceSpecification.IsSatisfied(input);
        }

        private ISpecification<PieceMovement> ResolveSpecification(PieceType pieceType)
        {
            return pieceType switch
            {
                PieceType.Pawn => new IsPawnMovementAllowed(),
                _ => throw new InvalidOperationException($"{pieceType} not allowed."),
            };
        }
    }
}
