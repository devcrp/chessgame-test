using ChessGame.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Interfaces
{
    public interface IGameRepository
    {
        Game CreateGame();

        Game Get(Guid id);
    }
}
