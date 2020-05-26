using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool IsCompleted => Movement != null;

        public Turn Start()
        {
            StartedTimeUtc = DateTime.UtcNow;
            return this;
        }

        public OperationResult<IPiece> Move(Guid pieceId, Position destination)
        {
            IPiece piece = Player.Pieces.Single(piece => piece.Id == pieceId);
            Movement = new Movement(piece, Position.Clone(piece.Position), Position.Clone(destination));
            return new OperationResult<IPiece>(piece, piece.Move(destination));
        }
    }
}
