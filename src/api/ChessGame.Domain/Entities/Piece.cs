using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entities
{
    public class Piece
    {
        public PieceType PieceType { get; }

        public static Piece Create(PieceType pieceType) => new Piece(pieceType);

        private Piece(PieceType pieceType)
        {
            PieceType = pieceType;
        }
    }
}
