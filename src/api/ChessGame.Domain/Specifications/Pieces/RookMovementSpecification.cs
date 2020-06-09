using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Specifications.Pieces
{
    public class RookMovementSpecification : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static RookMovementSpecification Create(Board board) => new RookMovementSpecification(board);

        private RookMovementSpecification(Board board)
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
