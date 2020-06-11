using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Specifications.Movements
{
    public class CastlingMovementSpecification : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static CastlingMovementSpecification Create(Board board) => new CastlingMovementSpecification(board);

        private CastlingMovementSpecification(Board board)
        {
            this._board = board;
        }

        public bool IsSatisfied(PieceMovement candidate)
        {
            string[] allowedDestinations = candidate.Piece.Color == PieceColor.White 
                                                    ? new[] { "C1", "G1" } 
                                                    : new[] { "C8", "G8" };

            if (candidate.Piece.Type == PieceType.King
                && !candidate.Piece.HasMoved
                && allowedDestinations.Contains(candidate.To.Id))
            {
                Square rookSquare = CastlingEvaluator.FindRookSquare(_board, candidate);
                return !rookSquare.IsEmpty && rookSquare.Piece.Type == PieceType.Rook && !rookSquare.Piece.HasMoved;
            }

            return false;
        }
    }
}
