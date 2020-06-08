using ChessGame.Api.Arguments;
using ChessGame.Api.Controllers;
using ChessGame.Application.Services;
using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using ChessGame.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ChessGame.Api.Tests
{
    public class Tests
    {
        GameController _gameController;

        [SetUp]
        public void Setup()
        {
            _gameController = new GameController(new GameService(new GameRepository()));
        }

        [Test]
        public void Start_Action_Should_Return_New_Guid()
        {
            ActionResult<Guid> response = _gameController.Start(new StartGameArguments
                                            {
                                                Player1 = "Carlos",
                                                Player2 = "Marta"
                                            });

            Assert.AreNotEqual(Guid.Empty, response.Value);
        }

        [Test]
        public void GetGameState_Action_Should_Return_Game_Object()
        {
            ActionResult<Guid> responseStart = _gameController.Start(new StartGameArguments
            {
                Player1 = "Carlos",
                Player2 = "Marta"
            });

            ActionResult<Game> response = _gameController.GetGameState(responseStart.Value);

            Assert.IsNotNull(response.Value);
            Assert.AreEqual(responseStart.Value, response.Value.Id);
        }

        [Test]
        public void Move_Action_Should_Return_List_Of_Events()
        {
            ActionResult<Guid> responseStart = _gameController.Start(new StartGameArguments
            {
                Player1 = "Carlos",
                Player2 = "Marta"
            });

            ActionResult<TurnLog> response = _gameController.Move(responseStart.Value, new MoveArguments
            {
                Origin = "C2",
                Destination = "C4"
            });

            Assert.IsNotNull(response.Value);
            Assert.AreNotEqual(0, response.Value.TurnEvents.Count);
        }
    }
}