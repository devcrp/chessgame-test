using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; }
        public string Name { get; }
        public PieceColor Color { get; }
        public List<TurnLog> TurnLogs { get; private set; } = new List<TurnLog>();


        public static Player Create(string name, PieceColor color) => new Player(name, color);

        private Player(string name, PieceColor color)
        {
            Id = Guid.NewGuid();
            Name = name;
            Color = color;
        }

        public void LogMove(TurnLog turnLog)
        {
            TurnLogs.Add(turnLog);
        }

        public TurnLog GetLastTurn() => TurnLogs.LastOrDefault();
    }
}
