using ChessGame.Application.Dtos.Results;
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
        private readonly IPlayerSession _playerSession;

        public GameService(IGameRepository gameRepository, IPlayerSession playerSession)
        {
            this._gameRepository = gameRepository;
            this._playerSession = playerSession;
        }

        public IEnumerable<Game> GetGames() => _gameRepository.List();

        public Game GetGame(Guid id) => _gameRepository.Get(id);

        public Guid PrepareGame()
        {
            Game game = Game.PrepareGame();
            return _gameRepository.Insert(game);
        }

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

        public MakeMoveResult MakeMove(Guid gameId, Position origin, Position destination)
        {
            Game game = GetGame(gameId);

            if (!game.CanStart)
                return MakeMoveResult.CreateFailedResult("The game needs two players to start.");
            if (game.IsOver)
                return MakeMoveResult.CreateFailedResult("Game is over, no more movements allowed.");

            if (game.CurrentTurnPlayer.Id != _playerSession.PlayerId)
                return MakeMoveResult.CreateFailedResult($"Player trying to move is not {game.CurrentTurnPlayer.Color} player.");

            Square originSquare = game.Board.GetSquare(origin.Id);
            if (originSquare.IsEmpty)
                return MakeMoveResult.CreateFailedResult($"Origin square {origin.Id} is empty.");

            if (originSquare.Piece.Color != game.CurrentTurnPlayer.Color)
                return MakeMoveResult.CreateFailedResult($"Piece to be moved does not belong to the {game.CurrentTurnPlayer.Color} player.");

            Piece piece = originSquare.Piece;
            Player currentTurnPlayer = game.CurrentTurnPlayer;
            bool success = game.Board.HandleMove(PieceMovement.Create(piece, origin, destination));

            return success ?
                        MakeMoveResult.CreateSuccessResult(currentTurnPlayer.GetLastTurn())
                        : MakeMoveResult.CreateFailedResult($"Movement was denied.");
        }
    }
}
