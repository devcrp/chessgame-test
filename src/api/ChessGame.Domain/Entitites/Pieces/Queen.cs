using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces.Base;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Entitites.Pieces
{
    public class Queen : BasePiece, IPiece
    {
        public Queen(Position position, Board board) : base(position, board)
        {

        }

        public override string Type { get; set; } = "queen";

        public override OperationResult IsPositionAllowed(Position destination, IPiece pieceAtDestination = null, List<IPiece> piecesInBetween = null)
        {
            if (piecesInBetween != null && piecesInBetween.Any())
                return OperationResult.Fail("Position not allowed.");

            return OperationResult.Fail("Position not allowed.");
        }
    }
}
