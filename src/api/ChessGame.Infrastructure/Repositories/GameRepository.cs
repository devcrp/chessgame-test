using ChessGame.Domain;
using ChessGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        static List<Game> _games = new List<Game>();

        public Guid Insert(Game game)
        {
            _games.Add(game);
            return game.Id;
        }

        public Game Get(Guid id) => _games.SingleOrDefault(game => game.Id == id);
    }
}
