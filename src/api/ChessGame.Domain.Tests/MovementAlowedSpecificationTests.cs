using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using ChessGame.Domain.ValueObjects.Specifications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Tests
{
    public class MovementAlowedSpecificationTests
    {
        [Test]
        public void Initial_Valid_Pawn_Movement_Is_Satisfied()
        {
            Piece whitePawn = Piece.Create(PieceType.Pawn, PieceColor.White);
            Piece blackPawn = Piece.Create(PieceType.Pawn, PieceColor.Black);

            IsMovementAllowed specification = new IsMovementAllowed();

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
        public void NotInitial_Valid_Pawn_Movement_Is_Satisfied()
        {
            Piece whitePawn = Piece.Create(PieceType.Pawn, PieceColor.White);
            Piece blackPawn = Piece.Create(PieceType.Pawn, PieceColor.Black);
            whitePawn.Moved();
            blackPawn.Moved();

            IsMovementAllowed specification = new IsMovementAllowed();

            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(whitePawn, Position.Create("A2"), Position.Create("A3")))
            );
            Assert.IsTrue(
                specification.IsSatisfied(PieceMovement.Create(blackPawn, Position.Create("A7"), Position.Create("A6")))
            );
        }

        [Test]
        public void Initial_Invalid_Pawn_Movement_Is_Not_Satisfied()
        {
            Piece whitePawn = Piece.Create(PieceType.Pawn, PieceColor.White);
            Piece blackPawn = Piece.Create(PieceType.Pawn, PieceColor.Black);

            IsMovementAllowed specification = new IsMovementAllowed();

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
        public void NotInitial_Invalid_Pawn_Movement_Is_Not_Satisfied()
        {
            Piece whitePawn = Piece.Create(PieceType.Pawn, PieceColor.White);
            Piece blackPawn = Piece.Create(PieceType.Pawn, PieceColor.Black);
            whitePawn.Moved();
            blackPawn.Moved();

            IsMovementAllowed specification = new IsMovementAllowed();

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(whitePawn, Position.Create("A2"), Position.Create("A4")))
            );

            Assert.IsFalse(
                specification.IsSatisfied(PieceMovement.Create(blackPawn, Position.Create("A7"), Position.Create("A5")))
            );
        }
    }
}
