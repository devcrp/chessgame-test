using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects
{
    public class Movement
    {
        public Movement(IPiece piece, Position origin, Position destination)
        {
            Piece = piece;
            Origin = origin;
            Destination = destination;
        }

        public IPiece Piece { get; }

        public Position Origin { get; }

        public Position Destination { get; }
    }
}
