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

        public override string Type { get; set; } = "pawn";

        public override OperationResult IsPositionAllowed(Position destination, IPiece pieceAtDestination)
        {
            if (pieceAtDestination != null
                && Math.Abs(destination.VPos - this.Position.VPos) == 1
                && Math.Abs(destination.HPos - this.Position.HPos) == 1)
            {
                return OperationResult.Success;
            }

            if (this.NumberOfMoves == 0)
            {
                if (this.Color == Color.White && this.Position.HPos == destination.HPos && destination.VPosBetween(3, 4))
                    return OperationResult.Success;
                else if (this.Color == Color.Black && this.Position.HPos == destination.HPos && destination.VPosBetween(5, 6))
                    return OperationResult.Success;
            }
            else
            {
                int vPosVariancy = this.Color == Color.White ? 1 : -1;

                if (this.Position.HPos == destination.HPos && destination.VPos == this.Position.VPos + vPosVariancy)
                    return OperationResult.Success;
            }

            return OperationResult.Fail("Position not allowed.");
        }
    }
}
