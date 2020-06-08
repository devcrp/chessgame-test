using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects.Specifications.Pieces
{
    public class IsRookMovementAllowed : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static IsRookMovementAllowed Create(Board board) => new IsRookMovementAllowed(board);

        private IsRookMovementAllowed(Board board)
        {
            this._board = board;
        }

        public bool IsSatisfied(PieceMovement input)
        {
            if (PositionComparer.FileDistanceAbs(input.From, input.To) == 0
                || PositionComparer.RankDistanceAbs(input.From, input.To) == 0)
            {
                return true;
            }

            return false;
        }
    }
}
