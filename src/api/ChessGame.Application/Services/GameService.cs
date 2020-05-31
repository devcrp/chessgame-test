using ChessGame.Application.EventHandlers;
using ChessGame.Domain.Entities;
using ChessGame.Domain.Entitites;
using ChessGame.Domain.Entitites.Base;
using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Events;
using ChessGame.Domain.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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

            IPiece piece = game.GetCurrentTurn().Player.Pieces.Single(piece => piece.Id == pieceId);

            // Add event handler for PieceMovedEvent.
            (piece as Entity).AddDomainEventHandler<PieceMovedEvent>(PieceMovedEventHandler.Create(game));
            return new OperationResult<IPiece>(piece, piece.Move(destination));
        }
    }
}
