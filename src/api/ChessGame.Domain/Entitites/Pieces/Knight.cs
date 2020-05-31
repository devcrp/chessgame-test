using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces.Base;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entitites.Pieces
{
    public class Knight : BasePiece, IPiece
    {
        public Knight(Position position) : base(position)
        {

        }

        public override string Type { get; set; } = "knight";

        public override OperationResult IsPositionAllowed(Position destination, IPiece pieceAtDestination)
        {
            if ((destination.VPos == this.Position.VPos + 2 || destination.VPos == this.Position.VPos - 2)
                && 
                (destination.HPos == this.Position.HPos - 1 || destination.HPos == this.Position.HPos + 1))
            {
                return OperationResult.Success;
            }

            return OperationResult.Fail("Position not allowed.");
        }
    }
}
