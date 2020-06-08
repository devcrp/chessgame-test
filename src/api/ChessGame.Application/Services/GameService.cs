using ChessGame.Domain;
using ChessGame.Domain.Entities;
using ChessGame.Domain.Events;
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

        public Game GetGame(Guid id) => _gameRepository.Get(id);

        public Guid StartNewGame(string whitesPlayerName, string blacksPlayerName)
        {
            Game game = Game.StartNewGame(whitesPlayerName, blacksPlayerName);
            return _gameRepository.Insert(game);
        }

        public Player GetCurrentTurnPlayer(Guid gameId)
        {
            Game game = _gameRepository.Get(gameId);
            return game.CurrentTurnPlayer;
        }

        public bool MakeMove(Guid gameId, Position origin, Position destination)
        {
            Game game = GetGame(gameId);

            Square originSquare = game.Board.GetSquare(origin.Id);
            if (originSquare.IsEmpty)
                return false;

            Piece piece = originSquare.Piece;
            return game.Board.HandleMove(PieceMovement.Create(piece, origin, destination));
        }
    }
}
