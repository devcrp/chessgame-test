using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Specifications
{
    public class IsMovementLandingOnEmptyOrOponentColor : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static IsMovementLandingOnEmptyOrOponentColor Create(Board board) => new IsMovementLandingOnEmptyOrOponentColor(board);

        private IsMovementLandingOnEmptyOrOponentColor(Board board)
        {
            this._board = board;
        }

        public bool IsSatisfied(PieceMovement candidate)
        {
            Square destinationSquare = _board.GetSquare(candidate.To.Id);
            return destinationSquare.IsEmpty || candidate.Piece.Color != destinationSquare.Piece.Color;
        }
    }
}
