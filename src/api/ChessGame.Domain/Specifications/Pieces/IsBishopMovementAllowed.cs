using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Specifications.Pieces
{
    public class IsBishopMovementAllowed : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static IsBishopMovementAllowed Create(Board board) => new IsBishopMovementAllowed(board);

        private IsBishopMovementAllowed(Board board)
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
