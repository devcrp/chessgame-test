using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using ChessGame.Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Tests
{
    public class CastlingEvaluatorTests
    {
        [Test]
        public void Castling_To_Right_Rook_Should_Return_Rook_Movement()
        {
            Board board = Board.Create();
            Piece whiteKing = Piece.Create(PieceType.King, PieceColor.White);
            board.AddPiece(whiteKing, "E1");
            board.AddPiece(Piece.Create(PieceType.Rook, PieceColor.White), "H1");

            CastlingEvaluationResult result = CastlingEvaluator.EvaluateCastling(board, PieceMovement.Create(whiteKing, Position.Create("E1"), Position.Create("G1")));
            Assert.IsNotNull(result.Rook);
            Assert.AreEqual("H1", result.From.Id);
            Assert.AreEqual("F1", result.To.Id);
        }

        [Test]
        public void Castling_To_Left_Rook_Should_Return_Rook_Movement()
        {
            Board board = Board.Create();
            Piece whiteKing = Piece.Create(PieceType.King, PieceColor.White);
            board.AddPiece(whiteKing, "E1");
            board.AddPiece(Piece.Create(PieceType.Rook, PieceColor.White), "A1");

            CastlingEvaluationResult result = CastlingEvaluator.EvaluateCastling(board, PieceMovement.Create(whiteKing, Position.Create("E1"), Position.Create("C1")));
            Assert.IsNotNull(result.Rook);
            Assert.AreEqual("A1", result.From.Id);
            Assert.AreEqual("D1", result.To.Id);
        }
    }
}
