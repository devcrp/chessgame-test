using ChessGame.Application.Services;
using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using ChessGame.Infrastructure.Repositories;
using NUnit.Framework;
using System;

namespace ChessGame.Application.Tests
{
    public class GameServiceTests
    {
        [Test]
        public void StartNewGame_Should_Return_A_Guid()
        {
            GameService gameService = new GameService(new GameRepository());
            Guid gameId = gameService.StartNewGame("Carlos", "Marta");
            Assert.AreNotEqual(Guid.Empty, gameId);
        }

        [Test]
        public void CurrentPlayer_After_StartNewGame_Should_Return_A_Whites()
        {
            GameService gameService = new GameService(new GameRepository());
            Guid gameId = gameService.StartNewGame("Carlos", "Marta");
            Game game = gameService.GetGame(gameId);

            Assert.AreEqual(game.WhitesPlayer, game.CurrentTurnPlayer);
        }

        [Test]
        public void MakeMove_Should_Change_Piece_Position()
        {
            GameService gameService = new GameService(new GameRepository());
            Guid gameId = gameService.StartNewGame("Carlos", "Marta");
            Game game = gameService.GetGame(gameId);

            Assert.IsFalse(game.Board.GetSquare("A2").IsEmpty);
            Assert.IsTrue(game.Board.GetSquare("A4").IsEmpty);

            bool success = gameService.MakeMove(gameId, Position.Create("A2"), Position.Create("A4"));

            Assert.IsTrue(success);
            Assert.IsTrue(game.Board.GetSquare("A2").IsEmpty);
            Assert.IsFalse(game.Board.GetSquare("A4").IsEmpty);
        }

        [Test]
        public void MakeMove_From_Empty_Square_Should_Return_Fail()
        {
            GameService gameService = new GameService(new GameRepository());
            Guid gameId = gameService.StartNewGame("Carlos", "Marta");
            Game game = gameService.GetGame(gameId);

            bool success = gameService.MakeMove(gameId, Position.Create("A3"), Position.Create("A4"));

            Assert.IsFalse(success);
            Assert.IsFalse(game.Board.GetSquare("A2").IsEmpty);
            Assert.IsTrue(game.Board.GetSquare("A3").IsEmpty);
        }
    }
}