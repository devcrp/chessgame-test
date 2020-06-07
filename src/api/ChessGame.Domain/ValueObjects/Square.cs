using ChessGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.ValueObjects
{
    public class Square
    {
        public Position Position { get; }
        public bool IsEmpty => Piece == null;
        public Piece Piece { get; set; }

        public static Square Create(string file, string rank) => new Square(file, rank);
        public static Square Create(int fileIndex, int rankIndex) => new Square(fileIndex, rankIndex);
        public static Square Create(string identifier)
        {
            return new Square(identifier[0].ToString(), identifier[1].ToString());
        }

        private Square(int fileIndex, int rankIndex)
        {
            Position = Position.Create(fileIndex, rankIndex);
        }

        private Square(string file, string rank)
        {
            Position = Position.Create(file, rank);
        }

        public void LandPiece(Piece piece) => Piece = piece;
    }
}
