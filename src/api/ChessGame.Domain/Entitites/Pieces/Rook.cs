using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces.Base;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Entitites.Pieces
{
    public class Rook : BasePiece, IPiece
    {
        public Rook(Position position, Board board) : base(position, board)
        {

        }

        public override string Type { get; set; } = "rook";

        public override OperationResult IsPositionAllowed(Position destination, IPiece pieceAtDestination = null, List<IPiece> piecesInBetween = null)
        {
            if (destination.Key == this.Position.Key || (piecesInBetween != null && piecesInBetween.Any()))
                return OperationResult.Fail("Position not allowed.");

            if (pieceAtDestination != null
                && pieceAtDestination.Color == this.Color
                && pieceAtDestination.GetType() == typeof(King)
                && this.NumberOfMoves == 0
                && pieceAtDestination.NumberOfMoves == 0)
            {
                return OperationResult.Success;
            }

            if (pieceAtDestination != null && pieceAtDestination.Color == this.Color)
            {
                return OperationResult.Fail("Position not allowed.");
            }

            if (this.Position.VPos == destination.VPos || this.Position.HPos == destination.HPos)
            {
                return OperationResult.Success;
            }

            return OperationResult.Fail("Position not allowed.");
        }
    }
}
