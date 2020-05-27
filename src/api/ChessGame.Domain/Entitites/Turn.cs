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

        public OperationResult<IPiece> MakeMove(Guid pieceId, Position destination)
        {
            IPiece piece = Player.Pieces.SingleOrDefault(piece => piece.Id == pieceId);
            if (piece == null)
            {
                return new OperationResult<IPiece>(OperationResult.Fail($"This piece does not belong to player {Player.Name}."));
            }

            OperationResult positionAllowedOperation = piece.IsPositionAllowed(destination, this.Player.Game.Board);
            if (!positionAllowedOperation.IsSuccessful)
                return new OperationResult<IPiece>(positionAllowedOperation);

            Movement = new Movement(piece, Position.Clone(piece.Position), Position.Clone(destination));
            return new OperationResult<IPiece>(piece, piece.Move(destination));
        }
    }
}
