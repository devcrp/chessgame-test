using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entitites
{
    public class Turn
    {
        public Turn(Player player)
        {
            Player = player;
        }

        public Player Player { get; }

        public DateTime StartedTimeUtc { get; private set; }

        public Movement Movement { get; private set; }

        public Turn Start()
        {
            StartedTimeUtc = DateTime.UtcNow;
            return this;
        }

        public void Move(IPiece piece, Position destination)
        {
            Movement = new Movement(piece, piece.Position, destination);
            piece.Move(destination);
        }
    }
}
