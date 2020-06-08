using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Entities
{
    public class Player
    {
        public string Name { get; }
        public PieceColor Color { get; }
        public List<TurnLog> TurnLogs { get; private set; } = new List<TurnLog>();


        public static Player Create(string name, PieceColor color) => new Player(name, color);

        private Player(string name, PieceColor color)
        {
            Name = name;
            Color = color;
        }

        public void LogMove(PieceMovement pieceMovement)
        {
            TurnLog turnLog = TurnLog.Create(pieceMovement);
            turnLog.AddEvent(TurnEvent.Create(EventType.Moved,
                                              Position.Create(pieceMovement.From.Id),
                                              Position.Create(pieceMovement.To.Id)));

            TurnLogs.Add(turnLog);
        }

        public void AddEventToLog(TurnEvent turnEvent)
        {
            TurnLogs.Last().AddEvent(turnEvent);
        }
    }
}
