using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Specifications.Pieces
{
    public class IsPawnMovementAllowed : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static IsPawnMovementAllowed Create(Board board) => new IsPawnMovementAllowed(board);

        private IsPawnMovementAllowed(Board board)
        {
            this._board = board;
        }

        public bool IsSatisfied(PieceMovement input)
        {
            if (PositionComparer.FileDistanceAbs(input.From, input.To) == 0)
            {
                int rankDistance = PositionComparer.RankDistance(input.From, input.To);

                if (input.Piece.Color == PieceColor.White
                    && rankDistance < 0 && rankDistance >= (input.Piece.HasMoved ? -1 : -2))
                {
                    return true;
                }
                
                if (input.Piece.Color == PieceColor.Black
                    && rankDistance > 0 && rankDistance <= (input.Piece.HasMoved ? 1 : 2))
                {
                    return true;
                }
            }
            else if (PositionComparer.FileDistanceAbs(input.From, input.To) == 1
                     && PositionComparer.RankDistanceAbs(input.From, input.To) == 1)
            {
                Square squareDestination = _board.GetSquare(input.To.Id);
                if (!squareDestination.IsEmpty && squareDestination.Piece.Color != input.Piece.Color)
                    return true;
            }

            return false;
        }
    }
}
