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


        public static Player Create(Guid id, string name, PieceColor color) => new Player(id, name, color);

        private Player(Guid id, string name, PieceColor color)
        {
            Id = id;
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
