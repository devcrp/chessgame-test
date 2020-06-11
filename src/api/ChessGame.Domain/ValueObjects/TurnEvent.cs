using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects
{
    public class TurnEvent
    {
        public EventType EventType { get; }
        public Position OriginalPosition { get; set; }
        public Position NewPosition { get; set; }

        public static TurnEvent CreateCapturedEvent(Position originalPosition) => new TurnEvent(EventType.Captured, originalPosition, null);

        public static TurnEvent CreateMovedEvent(Position originalPosition, Position newPosition) => new TurnEvent(EventType.Moved, originalPosition, newPosition);

        public static TurnEvent CreateGameOverEvent() => new TurnEvent(EventType.GameOver, null, null);

        private TurnEvent(EventType eventType, Position originalPosition, Position newPosition)
        {
            EventType = eventType;
            OriginalPosition = originalPosition;
            NewPosition = newPosition;
        }
    }
}
