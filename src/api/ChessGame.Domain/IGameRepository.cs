using ChessGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain
{
    public interface IGameRepository
    {
        Guid Insert(Game game);

        Game Get(Guid id);
        List<Game> List();
    }
}
