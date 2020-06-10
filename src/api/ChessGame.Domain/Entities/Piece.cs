using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entities
{
    public class Piece
    {
        public bool HasMoved { get; private set; }
        public PieceType Type { get; }
        public PieceColor Color { get; }
        public bool CanJump => Type == PieceType.Knight;

        public static Piece Create(PieceType type, PieceColor color) => new Piece(type, color);

        private Piece(PieceType type, PieceColor color)
        {
            Type = type;
            Color = color;
        }

        public void Moved() => HasMoved = true;
    }
}
