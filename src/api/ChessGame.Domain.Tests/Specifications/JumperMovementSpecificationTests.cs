﻿using ChessGame.Domain.Entities;
using ChessGame.Domain.Specifications.Movements;
using ChessGame.Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Tests.Specifications
{
    public class JumperMovementSpecificationTests
    {
        [Test]
        public void Straight_Jumper_Blacks_Movement_Should_Satisfy()
        {
            Board board = Board.CreateAndSetup();

            JumperMovementSpecification jumperMovementSpecification = JumperMovementSpecification.Create(board);

            PieceMovement pieceMovement = PieceMovement.Create(board.GetSquare("A8").Piece, 
                                                               Position.Create("A8"), 
                                                               Position.Create("A5"));

            Assert.IsTrue(jumperMovementSpecification.IsSatisfied(pieceMovement));
        }

        [Test]
        public void Straight_Not_Jumper_Blacks_Movement_Should_Not_Satisfy()
        {
            Board board = Board.CreateAndSetup();

            JumperMovementSpecification jumperMovementSpecification = JumperMovementSpecification.Create(board);

            PieceMovement pieceMovement = PieceMovement.Create(board.GetSquare("A7").Piece,
                                                               Position.Create("A7"),
                                                               Position.Create("A5"));

            Assert.IsFalse(jumperMovementSpecification.IsSatisfied(pieceMovement));
        }

        [Test]
        public void Straight_Jumper_Whites_Movement_Should_Satisfy()
        {
            Board board = Board.CreateAndSetup();

            JumperMovementSpecification jumperMovementSpecification = JumperMovementSpecification.Create(board);

            PieceMovement pieceMovement = PieceMovement.Create(board.GetSquare("A1").Piece, 
                                                               Position.Create("A1"), 
                                                               Position.Create("A5"));

            Assert.IsTrue(jumperMovementSpecification.IsSatisfied(pieceMovement));
        }

        [Test]
        public void Straight_Not_Jumper_Whites_Movement_Should_Not_Satisfy()
        {
            Board board = Board.CreateAndSetup();

            JumperMovementSpecification jumperMovementSpecification = JumperMovementSpecification.Create(board);

            PieceMovement pieceMovement = PieceMovement.Create(board.GetSquare("A2").Piece,
                                                               Position.Create("A2"),
                                                               Position.Create("A4"));

            Assert.IsFalse(jumperMovementSpecification.IsSatisfied(pieceMovement));
        }

        [Test]
        public void Diagonal_Jumper_Movement_Should_Satisfy()
        {
            Board board = Board.CreateAndSetup();

            JumperMovementSpecification jumperMovementSpecification = JumperMovementSpecification.Create(board);

            PieceMovement pieceMovement = PieceMovement.Create(board.GetSquare("C1").Piece,
                                                               Position.Create("C1"),
                                                               Position.Create("F4"));

            Assert.IsTrue(jumperMovementSpecification.IsSatisfied(pieceMovement));
        }

        [Test]
        public void Diagonal_Not_Jumper_Movement_Should_Not_Satisfy()
        {
            Board board = Board.Create();
            board.AddPiece(Piece.Create(PieceType.Bishop, PieceColor.White), "C1");

            JumperMovementSpecification jumperMovementSpecification = JumperMovementSpecification.Create(board);

            PieceMovement pieceMovement = PieceMovement.Create(board.GetSquare("C1").Piece,
                                                               Position.Create("C1"),
                                                               Position.Create("F4"));

            Assert.IsFalse(jumperMovementSpecification.IsSatisfied(pieceMovement));
        }
    }
}
