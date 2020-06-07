using ChessGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects.Specifications
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
            return candidate.Piece.Color != _board.GetSquare(candidate.To.Id).Piece.Color;
        }
    }
}
