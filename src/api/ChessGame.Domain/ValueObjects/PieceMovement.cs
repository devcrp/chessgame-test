using ChessGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects
{
    public class PieceMovement
    {
        public Piece Piece { get; }
        public Position From { get; }
        public Position To { get; }

        public static PieceMovement Create(Piece piece, Position from, Position to) => new PieceMovement(piece, from, to);

        private PieceMovement(Piece piece, Position from, Position to)
        {
            Piece = piece;
            From = from;
            To = to;
        }
    }
}
