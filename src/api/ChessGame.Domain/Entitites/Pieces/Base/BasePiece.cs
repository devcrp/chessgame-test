using ChessGame.Domain.Entitites.Base;
using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Events;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entitites.Pieces.Base
{
    public class BasePiece : Entity, IPiece
    {
        public BasePiece(Position position)
        {
            Position = position;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Position Position { get; set; }

        public Color Color { get; set; }

        public int NumberOfMoves { get; set; }
        
        public virtual string Type { get; set; }

        public virtual OperationResult IsPositionAllowed(Position destination, IPiece pieceAtDestination)
        {
            throw new NotImplementedException();
        }

        public OperationResult Move(Position destination)
        {
            Position originalPosition = Position.Clone(this.Position);
            this.Position = destination;
            NumberOfMoves++;

            AddDomainEvent(new PieceMovedEvent(this, new PieceMovedEventArguments(this, originalPosition, destination)));
            DispatchEvents();

            return OperationResult.Success;
        }
    }
}
