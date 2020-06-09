using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Specifications.Pieces
{
    public class KingMovementSpecification : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static KingMovementSpecification Create(Board board) => new KingMovementSpecification(board);

        private KingMovementSpecification(Board board)
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
