using ChessGame.Domain.ValueObjects;
using ChessGame.Domain.ValueObjects.Results;
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

        Board Board { get; set; }

        OperationResult IsPositionAllowed(Position destination, IPiece pieceAtDestination);

        OperationResult<MoveResult> Move(Position destination);
    }
}
