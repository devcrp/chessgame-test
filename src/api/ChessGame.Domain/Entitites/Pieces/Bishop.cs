using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces.Base;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entitites.Pieces
{
    public class Bishop : BasePiece, IPiece
    {
        public Bishop(Position position, Board board) : base(position, board)
        {

        }

        public override string Type { get; set; } = "bishop";

        public override OperationResult IsPositionAllowed(Position destination, IPiece pieceAtDestination)
        {
            if (Math.Abs(this.Position.VPos - destination.VPos) == Math.Abs(this.Position.HPos - destination.HPos))
                return OperationResult.Success;

            return OperationResult.Fail("Position not allowed.");
        }
    }
}
