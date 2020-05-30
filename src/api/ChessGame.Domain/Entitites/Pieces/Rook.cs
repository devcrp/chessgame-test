using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces.Base;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entitites.Pieces
{
    public class Rook : BasePiece, IPiece
    {
        public Rook(Position position) : base(position)
        {

        }

        public string Type { get; set; } = "rook";

        public override OperationResult IsPositionAllowed(Position position, Board board)
        {
            return OperationResult.Fail("");
        }
    }
}
