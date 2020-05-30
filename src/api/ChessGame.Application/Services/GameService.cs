﻿using ChessGame.Domain.Entitites;
using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Interfaces;
using ChessGame.Domain.ValueObjects;
using ChessGame.Domain.ValueObjects.Results;
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

        public OperationResult<Game> GetGame(Guid id) => new OperationResult<Game>(_gameRepository.Get(id));

        public OperationResult<Guid> StartNewGame(string whitesPlayerName, string blacksPlayerName)
        {
            Game game = _gameRepository.CreateGame();
            OperationResult startResult = game.Start(whitesPlayerName, blacksPlayerName);
            if (!startResult.IsSuccessful)
                return new OperationResult<Guid>(startResult);

            return new OperationResult<Guid>(game.Id);
        }

        public OperationResult<Turn> GetCurrentTurn(Guid gameId)
        {
            Game game = _gameRepository.Get(gameId);
            return new OperationResult<Turn>(game.GetCurrentTurn());
        }

        public OperationResult<IPiece> MakeMove(Guid gameId, Guid pieceId, Position destination)
        {
            Game game = GetGame(gameId);

            OperationResult<MoveValidationResult> validateOperation = game.Board.ValidateMove(pieceId, destination);
            if (!validateOperation.IsSuccessful)
            {
                return new OperationResult<IPiece>(validateOperation);
            }

            Turn currentTurn = game.GetCurrentTurn();
            OperationResult<IPiece> moveOperation = currentTurn.Player.MakeMove(pieceId, destination);
            if (!moveOperation.IsSuccessful)
                return moveOperation;

            if (validateOperation.Result.PieceKilled != null)
            {
                Player oponent = currentTurn.GetOponent();
                oponent.KillPiece(validateOperation.Result.PieceKilled);
            }

            game.SwitchTurn();

            return moveOperation;
        }
    }
}
