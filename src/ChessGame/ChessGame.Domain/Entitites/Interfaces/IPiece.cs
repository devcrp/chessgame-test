using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entitites.Interfaces
{
    public interface IPiece
    {
        Player Player { get; set; }

        Position Position { get; set; }

        bool Move(Position destination);
    }
}
