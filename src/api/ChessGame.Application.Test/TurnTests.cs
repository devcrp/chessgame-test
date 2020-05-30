using ChessGame.Application.Services;
using ChessGame.Domain.Entitites;
using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces;
using ChessGame.Domain.ValueObjects;
using ChessGame.Domain.ValueObjects.Results;
using ChessGame.Infrastructure.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Application.Test
{
    public class TurnTests
    {
        GameService _gameService;

        [SetUp]
        public void SetUp()
        {
            _gameService = new GameService(new GameRepository());
        }

        [Test]
        public void Get_CurrentTurn_After_StartGame_Should_Return_WhitePlayer()
        {
            const string WHITES_PLAYER = "Carlos";
            Guid gameId = _gameService.StartNewGame(WHITES_PLAYER, "Marta");
            OperationResult<Turn> currentTurnOperation = _gameService.GetCurrentTurn(gameId);
            Assert.IsTrue(currentTurnOperation.IsSuccessful);
            Assert.AreEqual(WHITES_PLAYER, currentTurnOperation.Result.Player.Name);
        }

        [Test]
        public void Move_Piece_Within_A_Turn_Should_Change_Piece_Position()
        {
            Guid gameId = _gameService.StartNewGame("Carlos", "Marta");
            Game game = _gameService.GetGame(gameId);
            OperationResult<Turn> currentTurnOperation = _gameService.GetCurrentTurn(gameId);
            Assert.IsTrue(currentTurnOperation.IsSuccessful);

            IPiece pawn = currentTurnOperation.Result.Player.Pieces.Single(piece => piece.Position.Key == "A2");
            Guid pawnId = pawn.Id;

            OperationResult<IPiece> makeMoveOperation = currentTurnOperation.Result.Player.MakeMove(pawnId, new Position(pawn.Position.HPos, pawn.Position.VPos + 2));

            Assert.IsTrue(makeMoveOperation.IsSuccessful);
            Assert.AreEqual("A4", pawn.Position.Key);
            Assert.IsNull(game.Board.GetPieces().SingleOrDefault(piece => piece.Position.Key == "A2"));
        }

        [Test]
        public void Move_Piece_Of_Wrong_Player_Should_Return_Error()
        {
            Guid gameId = _gameService.StartNewGame("Carlos", "Marta");
            ChessGame.Domain.Entitites.Game game = _gameService.GetGame(gameId);
            OperationResult<Turn> currentTurnOperation = _gameService.GetCurrentTurn(gameId);
            Assert.IsTrue(currentTurnOperation.IsSuccessful);

            IPiece pawn = game.BlacksPlayer.Pieces.Single(piece => piece.Position.Key == "A7");
            Guid pawnId = pawn.Id;

            OperationResult<MoveValidationResult> validateOperation = game.Board.ValidateMove(pawnId, new Position(pawn.Position.HPos, pawn.Position.VPos + 2));

            Assert.IsFalse(validateOperation.IsSuccessful);
        }
    }
}
