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
        public Knight(Position position, Board board) : base(position, board)
        {

        }

        public override string Type { get; set; } = "knight";

        public override OperationResult IsPositionAllowed(Position destination)
        {
            (List<IPiece> PiecesInBetween, IPiece PieceAtDestination) overlappingPieces = GetOverlappingPieces(destination);

            if (overlappingPieces.PieceAtDestination != null && overlappingPieces.PieceAtDestination.Color == this.Color)
                return OperationResult.Fail("Position not allowed.");

            if (((destination.VPos == this.Position.VPos + 2 || destination.VPos == this.Position.VPos - 2)
                && 
                (destination.HPos == this.Position.HPos - 1 || destination.HPos == this.Position.HPos + 1))
                ||
                ((destination.HPos == this.Position.HPos + 2 || destination.HPos == this.Position.HPos - 2)
                &&
                (destination.VPos == this.Position.VPos - 1 || destination.VPos == this.Position.VPos + 1)))
            {
                return OperationResult.Success;
            }

            return OperationResult.Fail("Position not allowed.");
        }
    }
}
