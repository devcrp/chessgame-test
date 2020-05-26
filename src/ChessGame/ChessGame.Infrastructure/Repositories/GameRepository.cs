using ChessGame.Domain.Entitites;
using ChessGame.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        static List<Game> _games = new List<Game>();

        public Game CreateGame()
        {
            Game game = new Game();
            _games.Add(game);
            return game;
        }
    }
}
