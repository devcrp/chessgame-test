using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Tests
{
    public class BoardTests
    {
        [Test]
        public void CreateAndSetupBoard_Should_Init_With_64_Squares()
        {
            Board board = Board.CreateAndSetup();
            Assert.AreEqual(64, board.Squares.Count);
        }

        [Test]
        public void CreateAndSetupBoard_Should_Init_With_32_Pieces()
        {
            Board board = Board.CreateAndSetup();
            Assert.AreEqual(32, board.Pieces.Count);
        }

        [Test]
        public void CreateAndSetupBoard_Should_Init_With_Pieces_Located_At_Their_Initial_Position()
        {
            Board board = Board.CreateAndSetup();

            Assert.AreEqual(PieceColor.White, board.GetSquare("A1").Piece.Color);
            Assert.AreEqual(PieceType.Rook, board.GetSquare("A1").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("B1").Piece.Color);
            Assert.AreEqual(PieceType.Knight, board.GetSquare("B1").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("C1").Piece.Color);
            Assert.AreEqual(PieceType.Bishop, board.GetSquare("C1").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("D1").Piece.Color);
            Assert.AreEqual(PieceType.Queen, board.GetSquare("D1").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("E1").Piece.Color);
            Assert.AreEqual(PieceType.King, board.GetSquare("E1").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("F1").Piece.Color);
            Assert.AreEqual(PieceType.Bishop, board.GetSquare("F1").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("G1").Piece.Color);
            Assert.AreEqual(PieceType.Knight, board.GetSquare("G1").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("H1").Piece.Color);
            Assert.AreEqual(PieceType.Rook, board.GetSquare("H1").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("A2").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("A2").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("B2").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("B2").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("C2").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("C2").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("D2").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("D2").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("E2").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("E2").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("F2").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("F2").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("G2").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("G2").Piece.Type);

            Assert.AreEqual(PieceColor.White, board.GetSquare("H2").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("H2").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("A8").Piece.Color);
            Assert.AreEqual(PieceType.Rook, board.GetSquare("A8").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("B8").Piece.Color);
            Assert.AreEqual(PieceType.Knight, board.GetSquare("B8").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("C8").Piece.Color);
            Assert.AreEqual(PieceType.Bishop, board.GetSquare("C8").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("D8").Piece.Color);
            Assert.AreEqual(PieceType.Queen, board.GetSquare("D8").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("E8").Piece.Color);
            Assert.AreEqual(PieceType.King, board.GetSquare("E8").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("F8").Piece.Color);
            Assert.AreEqual(PieceType.Bishop, board.GetSquare("F8").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("G8").Piece.Color);
            Assert.AreEqual(PieceType.Knight, board.GetSquare("G8").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("H8").Piece.Color);
            Assert.AreEqual(PieceType.Rook, board.GetSquare("H8").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("A7").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("A7").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("B7").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("B7").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("C7").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("C7").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("D7").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("D7").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("E7").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("E7").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("F7").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("F7").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("G7").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("G7").Piece.Type);

            Assert.AreEqual(PieceColor.Black, board.GetSquare("H7").Piece.Color);
            Assert.AreEqual(PieceType.Pawn, board.GetSquare("H7").Piece.Type);
        }
    }
}
