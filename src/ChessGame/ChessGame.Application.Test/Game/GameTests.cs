using ChessGame.Application.Services;
using ChessGame.Domain.ValueObjects;
using ChessGame.Infrastructure.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Application.Test.Game
{
    public class GameTests
    {
        GameService _gameService;

        [SetUp]
        public void SetUp()
        {
            _gameService = new GameService(new GameRepository());
        }

        [Test]
        public void Add_Game_Should_Return_Guid()
        {
            OperationResult<Guid> newGameOperationResult = _gameService.StartNewGame("Carlos", "Marta");
            Assert.AreNotEqual(Guid.Empty, newGameOperationResult);
            Assert.AreEqual(true, newGameOperationResult.IsSuccessful);
        }

        [Test]
        public void Add_Game_Should_Return_Errors()
        {
            OperationResult<Guid> newGameOperationResult = _gameService.StartNewGame("Carlos", "");
            Assert.AreEqual(false, newGameOperationResult.IsSuccessful);
        }
    }
}
