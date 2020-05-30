using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entitites.Pieces.Base
{
    public class BasePiece
    {
        public BasePiece(Position position)
        {
            Position = position;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Position Position { get; set; }

        public Color Color { get; set; }

        public int NumberOfMoves { get; set; }

        public virtual OperationResult IsPositionAllowed(Position destination, IPiece pieceAtDestination)
        {
            throw new NotImplementedException();
        }

        public OperationResult Move(Position destination)
        {
            this.Position = destination;
            NumberOfMoves++;
            return OperationResult.Success;
        }
    }
}
