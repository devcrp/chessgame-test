using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects
{
    public class TurnLog
    {
        public PieceMovement PieceMovement { get; private set; }

        public List<TurnEvent> TurnEvents { get; } = new List<TurnEvent>();

        public static TurnLog Create(PieceMovement pieceMovement)
        {
            return new TurnLog(pieceMovement);
        }

        private TurnLog(PieceMovement pieceMovement)
        {
            PieceMovement = pieceMovement;
        }

        public void AddEvent(TurnEvent turnEvent)
        {
            TurnEvents.Add(turnEvent);
        }
    }
}
