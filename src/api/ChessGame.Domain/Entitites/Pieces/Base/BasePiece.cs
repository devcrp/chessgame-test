using ChessGame.Domain.Entitites.Base;
using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.EventHandlers;
using ChessGame.Domain.Events;
using ChessGame.Domain.ValueObjects;
using ChessGame.Domain.ValueObjects.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Entitites.Pieces.Base
{
    public class BasePiece : Entity, IPiece
    {
        public BasePiece(Position position, Board board)
        {
            Position = position;
            Board = board;

            // Add event handler for PieceMovedEvent.
            this.AddDomainEventHandler<PieceMovedEvent>(PieceMovedEventHandler.Create());
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Position Position { get; set; }

        public Board Board { get; set; }

        public Color Color { get; set; }

        public int NumberOfMoves { get; set; }
        
        public virtual string Type { get; set; }

        public virtual OperationResult IsPositionAllowed(Position destination, IPiece pieceAtDestination)
        {
            throw new NotImplementedException();
        }

        public OperationResult<MoveResult> Move(Position destination)
        {
            OperationResult<MoveResult> result = ValidateAndFindKills(destination);
            if (!result.IsSuccessful)
                return result;

            Position originalPosition = Position.Clone(this.Position);
            this.Position = destination;
            NumberOfMoves++;

            AddDomainEvent(new PieceMovedEvent(this, new PieceMovedEventArguments(this, originalPosition, destination, result.Result)));
            DispatchEvents();

            return result;
        }

        private OperationResult<MoveResult> ValidateAndFindKills(Position destination)
        {
            var result = new MoveResult();

            IPiece pieceAtDestination = Board.GetPieces().SingleOrDefault(piece => piece.Position.Key == destination.Key);

            OperationResult positionAllowedOperation = this.IsPositionAllowed(destination, pieceAtDestination);
            if (!positionAllowedOperation.IsSuccessful)
                return new OperationResult<MoveResult>(positionAllowedOperation);

            if (pieceAtDestination != null && pieceAtDestination.Color != this.Color)
                result.KilledPiece = pieceAtDestination;

            return new OperationResult<MoveResult>(result);
        }
    }
}
