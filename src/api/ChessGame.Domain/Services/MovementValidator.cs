using ChessGame.Domain.Entities;
using ChessGame.Domain.Specifications;
using ChessGame.Domain.Specifications.Pieces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Services
{
    public static class MovementValidator
    {
        public static bool IsValid(Board board, PieceMovement candidate)
        {
            ISpecification<PieceMovement> pieceSpecification = ResolveSpecification(board, candidate.Piece.Type);
            return pieceSpecification.IsSatisfied(candidate);
        }

        public static ISpecification<PieceMovement> ResolveSpecification(Board board, PieceType pieceType)
        {
            return pieceType switch
            {
                PieceType.Pawn => PawnMovementSpecification.Create(board),
                PieceType.Rook => RookMovementSpecification.Create(board),
                PieceType.Knight => KnightMovementSpecification.Create(board),
                PieceType.Bishop => BishopMovementSpecification.Create(board),
                PieceType.Queen => QueenMovementSpecification.Create(board),
                PieceType.King => KingMovementSpecification.Create(board),
                _ => throw new InvalidOperationException($"{pieceType} not allowed."),
            };
        }
    }
}
