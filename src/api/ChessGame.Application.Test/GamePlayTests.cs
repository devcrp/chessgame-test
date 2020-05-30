using ChessGame.Application.Services;
using ChessGame.Domain.Entitites;
using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.ValueObjects;
using ChessGame.Infrastructure.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ChessGame.Application.Test
{
    public class GamePlayTests
    {
        GameService _gameService;

        [SetUp]
        public void SetUp()
        {
            _gameService = new GameService(new GameRepository());
        }

        private (string from, string to) GetMovement(string turn)
        {
            string from = turn.Split("->")[0];
            string to = turn.Split("->")[1];

            return (from, to);
        }

        private OperationResult<IPiece> DoMove(Game game, string turn)
        {
            (string from, string to) movementData = GetMovement(turn);

            Turn currentTurn = _gameService.GetCurrentTurn(game.Id);
            IPiece piece = game.Board.GetPieces().Single(piece => piece.Position.Key == movementData.from);
            Guid pieceId = piece.Id;
            TestContext.Out.WriteLine($"{piece.Type}: {turn}");

            OperationResult<IPiece> makeMoveOperation = _gameService.MakeMove(game.Id, pieceId, Position.Parse(movementData.to));

            return makeMoveOperation;
        }

        // https://www.mark-weeks.com/aboutcom/aa07c03.htm
        const string GAME_MOVES = "E2->E4;E7->E5;G1->F3;B8->C6;F1->C4;F8->C5;C2->C3;G8->F6;D2->D4;E5->D4;E4->E5";
        [Test]
        public void Play_Full_Game_Should_Finish([Values(GAME_MOVES)] string turnMoves)
        {
            string[] turns = turnMoves.Split(';');
            Guid gameId = _gameService.StartNewGame("Carlos", "Marta");
            Game game = _gameService.GetGame(gameId);
            for (int i = 0; i < turns.Length; i++)
            {
                var moveOperation = DoMove(game, turns[i]);
                Assert.IsTrue(moveOperation.IsSuccessful);
            }
        }
    }
}
