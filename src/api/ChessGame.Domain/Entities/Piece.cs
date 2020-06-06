using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entities
{
    public class Piece
    {
        public PieceType Type { get; }
        public PieceColor Color { get; }

        public static Piece Create(PieceType type, PieceColor color) => new Piece(type, color);

        private Piece(PieceType type, PieceColor color)
        {
            Type = type;
            Color = color;
        }
    }
}
