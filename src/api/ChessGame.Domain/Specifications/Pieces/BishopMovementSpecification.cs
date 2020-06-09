using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Specifications.Pieces
{
    public class BishopMovementSpecification : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static BishopMovementSpecification Create(Board board) => new BishopMovementSpecification(board);

        private BishopMovementSpecification(Board board)
        {
            this._board = board;
        }

        public bool IsSatisfied(PieceMovement input)
        {
            if (PositionComparer.FileDistanceAbs(input.From, input.To) == PositionComparer.RankDistanceAbs(input.From, input.To))
                return true;

            return false;
        }
    }
}
