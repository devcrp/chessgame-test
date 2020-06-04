using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces.Base;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entitites.Pieces
{
    public class King : BasePiece, IPiece
    {
        public King(Position position, Board board) : base(position, board)
        {

        }

        public override string Type { get; set; } = "king";

        public override OperationResult IsPositionAllowed(Position destination, IPiece pieceAtDestination = null, List<IPiece> piecesInBetween = null)
        {
            if (pieceAtDestination != null 
                && pieceAtDestination.Color == this.Color
                && pieceAtDestination.GetType() == typeof(Rook)
                && this.NumberOfMoves == 0
                && pieceAtDestination.NumberOfMoves == 0)
            {
                return OperationResult.Success;
            }

            if (Math.Abs(destination.VPos - this.Position.VPos) == 1 || Math.Abs(destination.HPos - this.Position.HPos) == 1)
            {
                return OperationResult.Success;
            }

            return OperationResult.Fail("Position not allowed.");
        }

        public List<Position> GetAvailablePositions()
        {
            List<Position> kingAvailablePositions = new List<Position>();
            kingAvailablePositions.Add(new Position(this.Position.HPos, this.Position.VPos));
            kingAvailablePositions.Add(new Position(this.Position.HPos, this.Position.VPos + 1));
            kingAvailablePositions.Add(new Position(this.Position.HPos, this.Position.VPos - 1));
            kingAvailablePositions.Add(new Position(this.Position.HPos + 1, this.Position.VPos));
            kingAvailablePositions.Add(new Position(this.Position.HPos + 1, this.Position.VPos + 1));
            kingAvailablePositions.Add(new Position(this.Position.HPos + 1, this.Position.VPos - 1));
            kingAvailablePositions.Add(new Position(this.Position.HPos - 1, this.Position.VPos));
            kingAvailablePositions.Add(new Position(this.Position.HPos - 1, this.Position.VPos + 1));
            kingAvailablePositions.Add(new Position(this.Position.HPos - 1, this.Position.VPos - 1));

            return kingAvailablePositions;
        }
    }
}
