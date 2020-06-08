using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Specifications.Pieces
{
    public class IsKingMovementAllowed : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static IsKingMovementAllowed Create(Board board) => new IsKingMovementAllowed(board);

        private IsKingMovementAllowed(Board board)
        {
            this._board = board;
        }

        public bool IsSatisfied(PieceMovement input)
        {
            if (PositionComparer.FileDistanceAbs(input.From, input.To) <= 1
                && PositionComparer.RankDistanceAbs(input.From, input.To) <= 1)
            {
                return true;
            }

            return false;
        }
    }
}
