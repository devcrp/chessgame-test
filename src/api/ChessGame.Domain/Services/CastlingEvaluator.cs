using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Services
{
    public static class CastlingEvaluator
    {
        public static Square FindRookSquare(Board board, PieceMovement pieceMovement)
        {
            if (pieceMovement.To.File == "G") // to right rook
            {
                return board.GetSquare(pieceMovement.To.FileIndex + 1, pieceMovement.To.RankIndex);
            }
            else if (pieceMovement.To.File == "C") // to left rook
            {
                return board.GetSquare(pieceMovement.To.FileIndex - 2, pieceMovement.To.RankIndex);
            }

            return null;
        }

        public static CastlingEvaluationResult EvaluateCastling(Board board, PieceMovement pieceMovement)
        {
            Square rookSquare = FindRookSquare(board, pieceMovement);
            int fileOffset = rookSquare.Position.File == "H" ? -2 : 3;
            return CastlingEvaluationResult.Create(rookSquare.Piece,
                                                Position.Create(rookSquare.Position.Id),
                                                Position.Create(rookSquare.Position.FileIndex + fileOffset, rookSquare.Position.RankIndex));
        }
    }
}
