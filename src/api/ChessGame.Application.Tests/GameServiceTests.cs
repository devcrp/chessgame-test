using ChessGame.Application.Dtos.Results;
using ChessGame.Application.Services;
using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using ChessGame.Infrastructure.Repositories;
using NUnit.Framework;
using System;
using System.Linq;

namespace ChessGame.Application.Tests
{
    public class GameServiceTests
    {
        [Test]
        public void Try_Movement_Before_Game_Can_Start_Should_Not_Be_Allowed()
        {
            GameService gameService = new GameService(new GameRepository());
            Guid gameId = gameService.PrepareGame();

            MakeMoveResult makeMoveResult = gameService.MakeMove(gameId, Position.Create("E2"), Position.Create("E4"));
            Assert.IsFalse(makeMoveResult.Success);
        }

        [Test]
        public void Movement_On_GameOver_Should_Not_Be_Allowed()
        {
            GameService gameService = new GameService(new GameRepository());
            Guid gameId = gameService.StartNewGame("Marta", "Carlos");

            MakeMoveResult makeMoveResult = gameService.MakeMove(gameId, Position.Create("E2"), Position.Create("E4"));
            Assert.IsTrue(makeMoveResult.Success);
            makeMoveResult = gameService.MakeMove(gameId, Position.Create("D7"), Position.Create("D5"));
            Assert.IsTrue(makeMoveResult.Success);
            makeMoveResult = gameService.MakeMove(gameId, Position.Create("F1"), Position.Create("B5"));
            Assert.IsTrue(makeMoveResult.Success);
            makeMoveResult = gameService.MakeMove(gameId, Position.Create("A7"), Position.Create("A6"));
            Assert.IsTrue(makeMoveResult.Success);
            makeMoveResult = gameService.MakeMove(gameId, Position.Create("B5"), Position.Create("E8"));
            Assert.IsTrue(makeMoveResult.Success);
            Assert.AreEqual(EventType.GameOver, makeMoveResult.TurnLog.TurnEvents.Last().EventType);
            Assert.IsTrue(gameService.GetGame(gameId).IsOver);
        }

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

            MakeMoveResult makeMoveResult = gameService.MakeMove(gameId, Position.Create("A2"), Position.Create("A4"));

            Assert.IsTrue(makeMoveResult.Success);
            Assert.IsTrue(game.Board.GetSquare("A2").IsEmpty);
            Assert.IsFalse(game.Board.GetSquare("A4").IsEmpty);
        }

        [Test]
        public void MakeMove_From_Empty_Square_Should_Return_Fail()
        {
            GameService gameService = new GameService(new GameRepository());
            Guid gameId = gameService.StartNewGame("Carlos", "Marta");
            Game game = gameService.GetGame(gameId);

            MakeMoveResult makeMoveResult = gameService.MakeMove(gameId, Position.Create("A3"), Position.Create("A4"));

            Assert.IsFalse(makeMoveResult.Success);
            Assert.IsFalse(game.Board.GetSquare("A2").IsEmpty);
            Assert.IsTrue(game.Board.GetSquare("A3").IsEmpty);
        }

        [Test]
        public void MakeMove_From_Incorrect_Turn_Should_Return_Fail()
        {
            GameService gameService = new GameService(new GameRepository());
            Guid gameId = gameService.StartNewGame("Carlos", "Marta");
            Game game = gameService.GetGame(gameId);

            MakeMoveResult makeMoveResult = gameService.MakeMove(gameId, Position.Create("A7"), Position.Create("A6"));

            Assert.IsFalse(makeMoveResult.Success);
        }
    }
}