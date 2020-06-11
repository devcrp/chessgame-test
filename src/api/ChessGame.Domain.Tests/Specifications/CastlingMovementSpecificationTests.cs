using ChessGame.Domain.Entities;
using ChessGame.Domain.Specifications.Movements;
using ChessGame.Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Tests.Specifications
{
    public class CastlingMovementSpecificationTests
    {
        [Test]
        public void White_Castiling_Movement_From_King_To_Right_Rook_Should_Satisfy()
        {
            Board board = Board.Create();
            Piece whiteKing = Piece.Create(PieceType.King, PieceColor.White);
            board.AddPiece(whiteKing, "E1");
            board.AddPiece(Piece.Create(PieceType.Rook, PieceColor.White), "H1");

            CastlingMovementSpecification castlingMovementSpecification = CastlingMovementSpecification.Create(board);
            bool isSatisfied = castlingMovementSpecification.IsSatisfied(PieceMovement.Create(whiteKing, Position.Create("E1"), Position.Create("G1")));
            Assert.IsTrue(isSatisfied);
        }

        [Test]
        public void White_Castiling_Movement_From_King_To_Left_Rook_Should_Satisfy()
        {
            Board board = Board.Create();
            Piece whiteKing = Piece.Create(PieceType.King, PieceColor.White);
            board.AddPiece(whiteKing, "E1");
            board.AddPiece(Piece.Create(PieceType.Rook, PieceColor.White), "A1");

            CastlingMovementSpecification castlingMovementSpecification = CastlingMovementSpecification.Create(board);
            bool isSatisfied = castlingMovementSpecification.IsSatisfied(PieceMovement.Create(whiteKing, Position.Create("E1"), Position.Create("C1")));
            Assert.IsTrue(isSatisfied);
        }

        [Test]
        public void Black_Castiling_Movement_From_King_To_Right_Rook_Should_Satisfy()
        {
            Board board = Board.Create();
            Piece blackKing = Piece.Create(PieceType.King, PieceColor.Black);
            board.AddPiece(blackKing, "E8");
            board.AddPiece(Piece.Create(PieceType.Rook, PieceColor.Black), "H8");

            CastlingMovementSpecification castlingMovementSpecification = CastlingMovementSpecification.Create(board);
            bool isSatisfied = castlingMovementSpecification.IsSatisfied(PieceMovement.Create(blackKing, Position.Create("E8"), Position.Create("G8")));
            Assert.IsTrue(isSatisfied);
        }

        [Test]
        public void Black_Castiling_Movement_From_King_To_Left_Rook_Should_Satisfy()
        {
            Board board = Board.Create();
            Piece blackKing = Piece.Create(PieceType.King, PieceColor.Black);
            board.AddPiece(blackKing, "E8");
            board.AddPiece(Piece.Create(PieceType.Rook, PieceColor.Black), "A8");

            CastlingMovementSpecification castlingMovementSpecification = CastlingMovementSpecification.Create(board);
            bool isSatisfied = castlingMovementSpecification.IsSatisfied(PieceMovement.Create(blackKing, Position.Create("E8"), Position.Create("C8")));
            Assert.IsTrue(isSatisfied);
        }

        [Test]
        public void White_Castiling_Movement_From_King_To_Right_Rook_Should_Not_Satisfy()
        {
            Board board = Board.Create();
            Piece whiteKing = Piece.Create(PieceType.King, PieceColor.White);
            board.AddPiece(whiteKing, "E1");

            CastlingMovementSpecification castlingMovementSpecification = CastlingMovementSpecification.Create(board);
            bool isSatisfied = castlingMovementSpecification.IsSatisfied(PieceMovement.Create(whiteKing, Position.Create("E1"), Position.Create("G1")));
            Assert.IsFalse(isSatisfied);
        }

        [Test]
        public void White_Castiling_Movement_From_King_To_Left_Rook_Should_Not_Satisfy()
        {
            Board board = Board.Create();
            Piece whiteKing = Piece.Create(PieceType.King, PieceColor.White);
            board.AddPiece(whiteKing, "E1");

            CastlingMovementSpecification castlingMovementSpecification = CastlingMovementSpecification.Create(board);
            bool isSatisfied = castlingMovementSpecification.IsSatisfied(PieceMovement.Create(whiteKing, Position.Create("E1"), Position.Create("C1")));
            Assert.IsFalse(isSatisfied);
        }

        [Test]
        public void Black_Castiling_Movement_From_King_To_Right_Rook_Should_Not_Satisfy()
        {
            Board board = Board.Create();
            Piece blackKing = Piece.Create(PieceType.King, PieceColor.Black);
            board.AddPiece(blackKing, "E8");

            CastlingMovementSpecification castlingMovementSpecification = CastlingMovementSpecification.Create(board);
            bool isSatisfied = castlingMovementSpecification.IsSatisfied(PieceMovement.Create(blackKing, Position.Create("E8"), Position.Create("G8")));
            Assert.IsFalse(isSatisfied);
        }

        [Test]
        public void Black_Castiling_Movement_From_King_To_Left_Rook_Should_Not_Satisfy()
        {
            Board board = Board.Create();
            Piece blackKing = Piece.Create(PieceType.King, PieceColor.Black);
            board.AddPiece(blackKing, "E8");

            CastlingMovementSpecification castlingMovementSpecification = CastlingMovementSpecification.Create(board);
            bool isSatisfied = castlingMovementSpecification.IsSatisfied(PieceMovement.Create(blackKing, Position.Create("E8"), Position.Create("C8")));
            Assert.IsFalse(isSatisfied);
        }
    }
}
