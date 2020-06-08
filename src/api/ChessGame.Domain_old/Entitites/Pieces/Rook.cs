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

        public override OperationResult IsPositionAllowed(Position destination)
        {
            (List<IPiece> PiecesInBetween, IPiece PieceAtDestination) overlappingPieces = GetOverlappingPieces(destination);

            if (destination.Key == this.Position.Key || (overlappingPieces.PiecesInBetween != null && overlappingPieces.PiecesInBetween.Any()))
                return OperationResult.Fail("Position not allowed.");

            if (overlappingPieces.PieceAtDestination != null
                && overlappingPieces.PieceAtDestination.Color == this.Color
                && overlappingPieces.PieceAtDestination.GetType() == typeof(King)
                && this.NumberOfMoves == 0
                && overlappingPieces.PieceAtDestination.NumberOfMoves == 0)
            {
                return OperationResult.Success;
            }

            if (overlappingPieces.PieceAtDestination != null && overlappingPieces.PieceAtDestination.Color == this.Color)
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
