﻿using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Tests
{
    public class GameTests
    {
        [Test]
        public void Prepare_Game_Should_Not_Add_Players()
        {
            Game game = Game.PrepareGame();
            Assert.IsNull(game.WhitesPlayer);
            Assert.IsNull(game.BlacksPlayer);
            Assert.IsFalse(game.CanStart);
        }

        [Test]
        public void Prepare_Game_And_Add_One_Player_Should_Not_Allow_Starting()
        {
            Game game = Game.PrepareGame();
            game.AddPlayer("Carlos");
            Assert.IsFalse(game.CanStart);
        }

        [Test]
        public void Prepare_Game_And_Add_Two_Players_Should_Allow_Starting()
        {
            Game game = Game.PrepareGame();
            game.AddPlayer("Carlos");
            game.AddPlayer("Marta");
            Assert.IsTrue(game.CanStart);
        }

        [Test]
        public void Capturing_The_King_Ends_Game()
        {
            Game game = Game.StartEmptyGame("Carlos", "Marta");
            game.Board.AddPiece(Piece.Create(PieceType.King, PieceColor.Black), "D4");
            Piece whiteRook = Piece.Create(PieceType.Rook, PieceColor.White);
            game.Board.AddPiece(whiteRook, "D1");

            bool success = game.Board.HandleMove(PieceMovement.Create(whiteRook, Position.Create("D1"), Position.Create("D4")));
            Assert.IsTrue(success);
            Assert.IsTrue(game.IsOver);
            Assert.AreEqual(game.WhitesPlayer, game.Winner);
        }

        [Test]
        public void StartNewGame_And_Move_Should_Register_Logs()
        {
            Game game = Game.StartNewGame("Carlos", "Marta");
            bool success = game.Board.HandleMove(PieceMovement.Create(game.Board.GetSquare("A2").Piece, Position.Create("A2"), Position.Create("A3")));
            Assert.IsTrue(success);
            Assert.AreEqual(1, game.WhitesPlayer.TurnLogs.Count);
            Assert.AreEqual(1, game.WhitesPlayer.TurnLogs[0].TurnEvents.Count);
        }

        [Test]
        public void StartNewGame_And_Move_To_Oponent_Square_Should_Register_Logs()
        {
            Game game = Game.StartEmptyGame("Carlos", "Marta");
            Piece whitePawn = Piece.Create(PieceType.Pawn, PieceColor.White);
            game.Board.AddPiece(whitePawn, "B3");
            game.Board.AddPiece(Piece.Create(PieceType.Pawn, PieceColor.Black), "C4");

            bool success = game.Board.HandleMove(PieceMovement.Create(game.Board.GetSquare("B3").Piece, Position.Create("B3"), Position.Create("C4")));
            Assert.IsTrue(success);
            Assert.AreEqual(1, game.WhitesPlayer.TurnLogs.Count);
            Assert.AreEqual(2, game.WhitesPlayer.TurnLogs[0].TurnEvents.Count);
        }

        [Test]
        public void StartNewGame_And_Move_Should_Switch_Turn()
        {
            Game game = Game.StartNewGame("Carlos", "Marta");
            game.Board.HandleMove(PieceMovement.Create(game.Board.GetSquare("A2").Piece, Position.Create("A2"), Position.Create("A3")));
            Assert.AreEqual(game.BlacksPlayer, game.CurrentTurnPlayer);
        }

        [Test]
        public void StartNewGame_Should_Initialize_Two_Players()
        {
            Game game = Game.StartNewGame("Carlos", "Marta");
            Assert.IsNotNull(game.WhitesPlayer);
            Assert.IsNotNull(game.BlacksPlayer);
            Assert.AreEqual("Carlos", game.WhitesPlayer.Name);
            Assert.AreEqual("Marta", game.BlacksPlayer.Name);
        }

        [Test]
        public void StartNewGame_Should_Set_CurrentTurnPlayer_To_Whites()
        {
            Game game = Game.StartNewGame("Carlos", "Marta");
            Assert.AreEqual(game.CurrentTurnPlayer, game.WhitesPlayer);
        }
    }
}
