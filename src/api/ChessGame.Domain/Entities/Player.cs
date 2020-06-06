using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entities
{
    public class Player
    {
        public string Name { get; }
        public PieceColor Color { get; }
        public List<TurnLog> TurnHistory { get; private set; }


        public static Player Create(string name, PieceColor color) => new Player(name, color);

        private Player(string name, PieceColor color)
        {
            Name = name;
            Color = color;
        }
    }
}
