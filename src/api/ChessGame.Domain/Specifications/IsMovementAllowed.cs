using ChessGame.Domain.Entities;
using ChessGame.Domain.Specifications.Pieces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Specifications
{
    public class IsMovementAllowed : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static IsMovementAllowed Create(Board board) => new IsMovementAllowed(board);

        private IsMovementAllowed(Board board)
        {
            this._board = board;
        }

        public bool IsSatisfied(PieceMovement candidate)
        {
            ISpecification<PieceMovement> pieceSpecification = ResolveSpecification(candidate.Piece.Type);
            return pieceSpecification.IsSatisfied(candidate);
        }

        private ISpecification<PieceMovement> ResolveSpecification(PieceType pieceType)
        {
            return pieceType switch
            {
                PieceType.Pawn => IsPawnMovementAllowed.Create(_board),
                PieceType.Rook => IsRookMovementAllowed.Create(_board),
                PieceType.Knight => IsKnightMovementAllowed.Create(_board),
                PieceType.Bishop => IsBishopMovementAllowed.Create(_board),
                PieceType.Queen => IsQueenMovementAllowed.Create(_board),
                PieceType.King => IsKingMovementAllowed.Create(_board),
                _ => throw new InvalidOperationException($"{pieceType} not allowed."),
            };
        }
    }
}
