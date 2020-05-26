using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entitites.Interfaces
{
    public interface IPiece
    {
        Guid Id { get; set; }

        string Type { get; set; }

        Position Position { get; set; }

        Color Color { get; set; }

        OperationResult Move(Position destination);
    }
}
