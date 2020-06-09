using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Specifications.Movements
{
    public class JumperMovementSpecification : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static JumperMovementSpecification Create(Board board) => new JumperMovementSpecification(board);

        private JumperMovementSpecification(Board board)
        {
            this._board = board;
        }

        public bool IsSatisfied(PieceMovement candidate)
        {
            if (candidate.From.FileIndex == candidate.To.FileIndex
                || candidate.From.RankIndex == candidate.To.RankIndex)
            {
                return StraightMovementIsSatisfied(candidate);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private bool StraightMovementIsSatisfied(PieceMovement candidate)
        {
            bool isJumper;
            if (candidate.From.FileIndex == candidate.To.FileIndex)
            {
                isJumper = _board.Squares.Where(square => square.Position.FileIndex == candidate.From.FileIndex
                                               && square.Position.RankIndex > candidate.From.RankIndex
                                               && square.Position.RankIndex < candidate.To.RankIndex)
                                         .Any(square => !square.IsEmpty);
            }
            else
            {
                isJumper = _board.Squares.Where(square => square.Position.RankIndex == candidate.From.RankIndex
                                               && square.Position.FileIndex > candidate.From.FileIndex
                                               && square.Position.FileIndex < candidate.To.FileIndex)
                                         .Any(square => !square.IsEmpty);
            }

            return isJumper;
        }
    }
}
