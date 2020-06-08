using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using ChessGame.Domain.ValueObjects.Specifications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Tests.Specifications
{
    public class MovementAlowedSpecificationTests
    {
        Board _board;

        [SetUp]
        public void Setup()
        {
            _board = Board.Create();
        }

        #region King

        [Test]
        public void Valid_King_Movement_Should_Satisfy()
        {
            Piece whiteKing = Piece.Create(PieceType.King, PieceColor.White);
            Piece blackKing = Piece.Create(PieceType.King, PieceColor.Black);

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whiteKing, Position.Create("E1"), Position.Create("E2")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whiteKing, Position.Create("E1"), Position.Create("F1")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whiteKing, Position.Create("E1"), Position.Create("D2")))
            );

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackKing, Position.Create("E8"), Position.Create("E7")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackKing, Position.Create("E8"), Position.Create("F8")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackKing, Position.Create("E8"), Position.Create("F7")))
            );
        }

        [Test]
        public void Inalid_King_Movement_Should_Not_Satisfy()
        {
            Piece whiteKing = Piece.Create(PieceType.King, PieceColor.White);
            Piece blackKing = Piece.Create(PieceType.King, PieceColor.Black);

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(whiteKing, Position.Create("E1"), Position.Create("E3")))
            );

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(whiteKing, Position.Create("E1"), Position.Create("H1")))
            );

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(blackKing, Position.Create("E8"), Position.Create("G6")))
            );
            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(blackKing, Position.Create("E8"), Position.Create("E1")))
            );
        }

        #endregion King

        #region Queen

        [Test]
        public void Valid_Queen_Movement_Should_Satisfy()
        {
            Piece whiteQueen = Piece.Create(PieceType.Queen, PieceColor.White);
            Piece blackQueen = Piece.Create(PieceType.Queen, PieceColor.Black);

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whiteQueen, Position.Create("D1"), Position.Create("H1")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whiteQueen, Position.Create("D1"), Position.Create("D8")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whiteQueen, Position.Create("D1"), Position.Create("G4")))
            );

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackQueen, Position.Create("D8"), Position.Create("A8")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackQueen, Position.Create("D8"), Position.Create("D3")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackQueen, Position.Create("D8"), Position.Create("H4")))
            );
        }

        [Test]
        public void Inalid_Queen_Movement_Should_Not_Satisfy()
        {
            Piece whiteQueen = Piece.Create(PieceType.Queen, PieceColor.White);
            Piece blackQueen = Piece.Create(PieceType.Queen, PieceColor.Black);

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(whiteQueen, Position.Create("D1"), Position.Create("C3")))
            );

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(whiteQueen, Position.Create("D1"), Position.Create("A5")))
            );

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(blackQueen, Position.Create("D8"), Position.Create("E6")))
            );
            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(blackQueen, Position.Create("D8"), Position.Create("F5")))
            );
        }

        #endregion Queen

        #region Bishop

        [Test]
        public void Valid_Bishop_Movement_Should_Satisfy()
        {
            Piece whiteBishop = Piece.Create(PieceType.Bishop, PieceColor.White);
            Piece blackBishop = Piece.Create(PieceType.Bishop, PieceColor.Black);

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whiteBishop, Position.Create("C1"), Position.Create("A3")))
            );

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whiteBishop, Position.Create("C1"), Position.Create("F4")))
            );

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackBishop, Position.Create("C8"), Position.Create("G4")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackBishop, Position.Create("C8"), Position.Create("A6")))
            );
        }

        [Test]
        public void Inalid_Bishop_Movement_Should_Not_Satisfy()
        {
            Piece whiteBishop = Piece.Create(PieceType.Bishop, PieceColor.White);
            Piece blackBishop = Piece.Create(PieceType.Bishop, PieceColor.Black);

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(whiteBishop, Position.Create("C1"), Position.Create("C3")))
            );

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(whiteBishop, Position.Create("C1"), Position.Create("H1")))
            );

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(blackBishop, Position.Create("C8"), Position.Create("D6")))
            );
            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(blackBishop, Position.Create("C8"), Position.Create("A8")))
            );
        }

        #endregion Bishop

        #region Knight

        [Test]
        public void Valid_Knight_Movement_Should_Satisfy()
        {
            Piece whiteKnight = Piece.Create(PieceType.Knight, PieceColor.White);
            Piece blackKnight = Piece.Create(PieceType.Knight, PieceColor.Black);

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whiteKnight, Position.Create("B1"), Position.Create("A3")))
            );

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whiteKnight, Position.Create("B1"), Position.Create("D2")))
            );

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackKnight, Position.Create("B8"), Position.Create("A6")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackKnight, Position.Create("B8"), Position.Create("D7")))
            );
        }

        [Test]
        public void Inalid_Knight_Movement_Should_Not_Satisfy()
        {
            Piece whiteKnight = Piece.Create(PieceType.Knight, PieceColor.White);
            Piece blackKnight = Piece.Create(PieceType.Knight, PieceColor.Black);

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(whiteKnight, Position.Create("B1"), Position.Create("B3")))
            );

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(whiteKnight, Position.Create("B1"), Position.Create("C2")))
            );

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(blackKnight, Position.Create("B8"), Position.Create("B5")))
            );
            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(blackKnight, Position.Create("B8"), Position.Create("D8")))
            );
        }

        #endregion Knight

        #region Rook

        [Test]
        public void Valid_Rook_Movement_Should_Satisfy()
        {
            Piece whiteRook = Piece.Create(PieceType.Rook, PieceColor.White);
            Piece blackRook = Piece.Create(PieceType.Rook, PieceColor.Black);

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whiteRook, Position.Create("A1"), Position.Create("A6")))
            );

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackRook, Position.Create("A8"), Position.Create("A5")))
            );
        }

        [Test]
        public void Inalid_Rook_Movement_Should_Not_Satisfy()
        {
            Piece whiteRook = Piece.Create(PieceType.Rook, PieceColor.White);
            Piece blackRook = Piece.Create(PieceType.Rook, PieceColor.Black);

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(whiteRook, Position.Create("A1"), Position.Create("C3")))
            );

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(blackRook, Position.Create("A8"), Position.Create("C6")))
            );
        }

        #endregion Rook

        #region Pawn

        [Test]
        public void Initial_Valid_Pawn_Movement_Should_Satisfy()
        {
            Piece whitePawn = Piece.Create(PieceType.Pawn, PieceColor.White);
            Piece blackPawn = Piece.Create(PieceType.Pawn, PieceColor.Black);

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whitePawn, Position.Create("A2"), Position.Create("A3")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whitePawn, Position.Create("A2"), Position.Create("A4")))
            );

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackPawn, Position.Create("A7"), Position.Create("A6")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackPawn, Position.Create("A7"), Position.Create("A5")))
            );
        }

        [Test]
        public void NotInitial_Valid_Pawn_Movement_Should_Satisfy()
        {
            Piece whitePawn = Piece.Create(PieceType.Pawn, PieceColor.White);
            Piece blackPawn = Piece.Create(PieceType.Pawn, PieceColor.Black);
            whitePawn.Moved();
            blackPawn.Moved();

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whitePawn, Position.Create("A2"), Position.Create("A3")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackPawn, Position.Create("A7"), Position.Create("A6")))
            );
        }

        [Test]
        public void Initial_Invalid_Pawn_Movement_Should_Not_Satisfy()
        {
            Piece whitePawn = Piece.Create(PieceType.Pawn, PieceColor.White);
            Piece blackPawn = Piece.Create(PieceType.Pawn, PieceColor.Black);

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(whitePawn, Position.Create("A2"), Position.Create("A5")))
            );
            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(whitePawn, Position.Create("A2"), Position.Create("A1")))
            );

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(blackPawn, Position.Create("A7"), Position.Create("A4")))
            );
            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(blackPawn, Position.Create("A7"), Position.Create("A8")))
            );
        }

        [Test]
        public void NotInitial_Invalid_Pawn_Movement_Should_Not_Satisfy()
        {
            Piece whitePawn = Piece.Create(PieceType.Pawn, PieceColor.White);
            Piece blackPawn = Piece.Create(PieceType.Pawn, PieceColor.Black);
            whitePawn.Moved();
            blackPawn.Moved();

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(whitePawn, Position.Create("A2"), Position.Create("A4")))
            );

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(blackPawn, Position.Create("A7"), Position.Create("A5")))
            );
        }

        [Test]
        public void Diagonal_Pawn_Movement_Should_Satisfy()
        {
            Piece whitePawn = Piece.Create(PieceType.Pawn, PieceColor.White);
            Piece blackPawn = Piece.Create(PieceType.Pawn, PieceColor.Black);
            _board.AddPiece(whitePawn, "D4");
            _board.AddPiece(blackPawn, "C5");

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whitePawn, Position.Create("D4"), Position.Create("C5")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackPawn, Position.Create("C5"), Position.Create("D4")))
            );
        }

        [Test]
        public void Diagonal_Pawn_Movement_Should_Not_Satisfy()
        {
            Piece whitePawn = Piece.Create(PieceType.Pawn, PieceColor.White);
            _board.AddPiece(whitePawn, "D4");

            IsMovementAllowed specification = IsMovementAllowed.Create(_board);

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(whitePawn, Position.Create("D4"), Position.Create("C5")))
            );
        }

        #endregion Pawn
    }
}
