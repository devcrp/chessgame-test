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
        public King(Position position) : base(position)
        {

        }

        public string Type { get; set; } = "king";

        public override OperationResult IsPositionAllowed(Position destination, IPiece pieceAtDestination)
        {
            return OperationResult.Fail("");
        }
    }
}
