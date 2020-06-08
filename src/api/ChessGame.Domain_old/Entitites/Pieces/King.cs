using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces.Base;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Entitites.Pieces
{
    public class King : BasePiece, IPiece
    {
        public King(Position position, Board board) : base(position, board)
        {

        }

        public override string Type { get; set; } = "king";

        public override OperationResult IsPositionAllowed(Position destination)
        {
            (List<IPiece> PiecesInBetween, IPiece PieceAtDestination) overlappingPieces = GetOverlappingPieces(destination);

            if (destination.Key == this.Position.Key)
                return OperationResult.Fail("Position not allowed.");

            if (overlappingPieces.PieceAtDestination != null 
                && overlappingPieces.PieceAtDestination.Color == this.Color
                && overlappingPieces.PieceAtDestination.GetType() == typeof(Rook)
                && this.NumberOfMoves == 0
                && overlappingPieces.PieceAtDestination.NumberOfMoves == 0)
            {
                return OperationResult.Success;
            }

            if (overlappingPieces.PieceAtDestination != null && overlappingPieces.PieceAtDestination.Color == this.Color)
                return OperationResult.Fail("Position not allowed.");

            if (Math.Abs(destination.VPos - this.Position.VPos) <= 1 && Math.Abs(destination.HPos - this.Position.HPos) <= 1)
            {
                return OperationResult.Success;
            }

            return OperationResult.Fail("Position not allowed.");
        }

        public List<Position> GetAvailablePositions()
        {
            int vPlusOne = Math.Min(Board.Size.Height, this.Position.VPos + 1);
            int vMinusOne = Math.Max(1, this.Position.VPos - 1);
            int hPlusOne = Math.Min(Board.Size.Width, this.Position.HPos + 1);
            int hMinusOne = Math.Max(1, this.Position.HPos - 1);

            List<Position> kingAvailablePositions = new List<Position>();
            kingAvailablePositions.Add(new Position(this.Position.HPos, this.Position.VPos));
            kingAvailablePositions.Add(new Position(this.Position.HPos, vPlusOne));
            kingAvailablePositions.Add(new Position(this.Position.HPos, vMinusOne));
            kingAvailablePositions.Add(new Position(hPlusOne, this.Position.VPos));
            kingAvailablePositions.Add(new Position(hPlusOne, vPlusOne));
            kingAvailablePositions.Add(new Position(hPlusOne, vMinusOne));
            kingAvailablePositions.Add(new Position(hMinusOne, this.Position.VPos));
            kingAvailablePositions.Add(new Position(hMinusOne, vPlusOne));
            kingAvailablePositions.Add(new Position(hMinusOne, vMinusOne));

            List<string> sameColorTakenPositions = Board.GetPieces()
                                                    .Where(piece => piece.Color == this.Color)
                                                    .Select(piece => piece.Position.Key)
                                                    .ToList();

            return kingAvailablePositions
                    .Where(position => position.Key == this.Position.Key || !sameColorTakenPositions.Contains(position.Key))
                    .ToList();
        }
    }
}
