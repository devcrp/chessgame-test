using ChessGame.Domain.Entitites.Base;
using ChessGame.Domain.Entitites.Interfaces;
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
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Position Position { get; set; }

        public Board Board { get; }

        public Color Color { get; set; }

        public int NumberOfMoves { get; set; }
        
        public virtual string Type { get; set; }

        public virtual OperationResult IsPositionAllowed(Position destination, IPiece pieceAtDestination)
        {
            throw new NotImplementedException();
        }

        public OperationResult<MoveResult> Move(Position destination)
        {
            OperationResult<MoveResult> validateOperation = ValidatePosition(destination);
            if (!validateOperation.IsSuccessful)
                return validateOperation;

            Position originalPosition = Position.Clone(this.Position);
            this.Position = destination;
            NumberOfMoves++;

            AddDomainEvent(new PieceMovedEvent(this, new PieceMovedEventArguments(this, originalPosition, destination, validateOperation.Result.PieceKilled)));
            DispatchEvents();

            return validateOperation;
        }

        private OperationResult<MoveResult> ValidatePosition(Position destination)
        {
            var result = new MoveResult();

            IPiece pieceAtDestination = Board.GetPieces().SingleOrDefault(piece => piece.Position.Key == destination.Key);

            OperationResult positionAllowedOperation = this.IsPositionAllowed(destination, pieceAtDestination);
            if (!positionAllowedOperation.IsSuccessful)
                return new OperationResult<MoveResult>(positionAllowedOperation);

            if (pieceAtDestination != null && pieceAtDestination.Color != this.Color)
                result.PieceKilled = pieceAtDestination;

            return new OperationResult<MoveResult>(result);
        }
    }
}
