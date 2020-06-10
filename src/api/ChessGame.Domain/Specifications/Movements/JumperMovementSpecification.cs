using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
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
            if (PositionComparer.FileDistanceAbs(candidate.From, candidate.To) <= 1 
                && PositionComparer.RankDistanceAbs(candidate.From, candidate.To) <= 1)
                return false;

            if (candidate.From.FileIndex == candidate.To.FileIndex
                || candidate.From.RankIndex == candidate.To.RankIndex)
            {
                return StraightMovementIsSatisfied(candidate);
            }
            else
            {
                return DiagonalMovementIsSatisfied(candidate);
            }
        }

        private bool DiagonalMovementIsSatisfied(PieceMovement candidate)
        {
            int fileModifier = PositionComparer.FileDistance(candidate.To, candidate.From) < 0 ? -1 : 1;
            int rankModifier = PositionComparer.RankDistance(candidate.To, candidate.From) < 0 ? -1 : 1;
            int fileIdx = candidate.From.FileIndex + fileModifier;
            int rankIdx = candidate.From.RankIndex + rankModifier;

            Func<bool> fileHasNext = () => fileIdx > 0 ? fileIdx < candidate.To.FileIndex
                                                       : fileIdx > candidate.To.FileIndex;
            Func<bool> rankHasNext = () => rankIdx > 0 ? rankIdx < candidate.To.RankIndex
                                                       : rankIdx > candidate.To.RankIndex;

            while (fileHasNext() || rankHasNext())
            {
                Position pos = Position.Create(fileIdx, rankIdx);
                if (!_board.GetSquare(pos.Id).IsEmpty)
                    return true;

                fileIdx += fileModifier;
                rankIdx += rankModifier;
            }

            return false;
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
