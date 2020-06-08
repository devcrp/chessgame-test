using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Specifications.Pieces
{
    public class IsKnightMovementAllowed : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static IsKnightMovementAllowed Create(Board board) => new IsKnightMovementAllowed(board);

        private IsKnightMovementAllowed(Board board)
        {
            this._board = board;
        }

        public bool IsSatisfied(PieceMovement input)
        {
            if ((PositionComparer.FileDistanceAbs(input.From, input.To) == 2 && PositionComparer.RankDistanceAbs(input.From, input.To) == 1)
                || (PositionComparer.FileDistanceAbs(input.From, input.To) == 1 && PositionComparer.RankDistanceAbs(input.From, input.To) == 2))
            {
                return true;
            }

            return false;
        }
    }
}
