using ChessGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects
{
    public class Square
    {
        public string Id { get; }
        public Piece Piece { get; set; }

        public static Square Create(string id) => new Square(id);

        private Square(string id)
        {
            Id = id;
        }

        public void LandPiece(Piece piece) => Piece = piece;
    }
}
