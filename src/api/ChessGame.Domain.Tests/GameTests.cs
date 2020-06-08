using ChessGame.Domain.Entities;
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
