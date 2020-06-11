using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using ChessGame.Domain.Specifications.Movements;
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

        public bool IsSatisfied(PieceMovement candidate)
        {
            if (PositionComparer.FileDistanceAbs(candidate.From, candidate.To) <= 1
                && PositionComparer.RankDistanceAbs(candidate.From, candidate.To) <= 1)
            {
                return true;
            }
            else
            {
                CastlingMovementSpecification castlingMovementSpecification = CastlingMovementSpecification.Create(_board);
                return castlingMovementSpecification.IsSatisfied(candidate);
            }
        }
    }
}
