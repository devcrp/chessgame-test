using ChessGame.Application.Services;
using ChessGame.Domain.Entitites;
using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.ValueObjects;
using ChessGame.Infrastructure.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Application.Test
{
    public class PiecesTests
    {
        GameService _gameService;

        [SetUp]
        public void SetUp()
        {
            _gameService = new GameService(new GameRepository());
        }

        [Test]
        public void Move_Piece_To_Allowed_Position_Should_Move_Piece([Values("A2->A4", "A7->A5", "A1->A6")] string from_to)
        {
            string from = from_to.Split("->")[0];
            string to = from_to.Split("->")[1];

            Guid gameId = _gameService.StartNewGame("Carlos", "Marta");
            Game game = _gameService.GetGame(gameId);
            var currentTurnOperation = _gameService.GetCurrentTurn(gameId);
            IPiece piece = game.WhitesPlayer.Pieces.Single(piece => piece.Position.Key == from);
            Guid pieceId = piece.Id;
            OperationResult<IPiece> moveOperation = currentTurnOperation.Result.MakeMove(pieceId, Position.Parse(to));

            Assert.IsTrue(moveOperation.IsSuccessful);
        }

        [Test]
        public void Move_Piece_To_NotAllowed_Position_Should_Return_Error([Values("A2->A5", "A7->A4", "A1->B2")] string from_to)
        {
            string from = from_to.Split("->")[0];
            string to = from_to.Split("->")[1];

            Guid gameId = _gameService.StartNewGame("Carlos", "Marta");
            Game game = _gameService.GetGame(gameId);
            var currentTurnOperation = _gameService.GetCurrentTurn(gameId);
            IPiece piece = game.WhitesPlayer.Pieces.Single(piece => piece.Position.Key == from);
            Guid pieceId = piece.Id;
            OperationResult<IPiece> moveOperation = currentTurnOperation.Result.MakeMove(pieceId, Position.Parse(to));

            Assert.IsFalse(moveOperation.IsSuccessful);
            Assert.AreEqual("Position not allowed.", moveOperation.Errors.First());
        }
    }
}
