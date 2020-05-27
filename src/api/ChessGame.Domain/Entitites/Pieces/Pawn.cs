using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces.Base;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entitites.Pieces
{
    public class Pawn : BasePiece, IPiece
    {
        public Pawn(Position position) : base (position)
        {

        }

        public string Type { get; set; } = "pawn";

        public override OperationResult IsPositionAllowed(Position destination, Board board)
        {
            if (this.Position.VPos == 2)
            {
                if (this.Position.HPos == destination.HPos && destination.VPos > 2 && destination.VPos <= 4)
                    return OperationResult.Success;
                return OperationResult.Fail("Position not allowed.");
            }

            return OperationResult.Success;
        }
    }
}
