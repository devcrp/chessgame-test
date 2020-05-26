using ChessGame.Domain.Entitites;
using ChessGame.Domain.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Application.Services
{
    public class GameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            this._gameRepository = gameRepository;
        }

        public OperationResult<Guid> StartNewGame(string player1Name, string player2Name)
        {
            Game game = _gameRepository.CreateGame();
            OperationResult startResult = game.Start(player1Name, player2Name);
            if (!startResult.IsSuccessful)
                return new OperationResult<Guid>(startResult);

            return new OperationResult<Guid>(game.Id);
        }
    }
}
