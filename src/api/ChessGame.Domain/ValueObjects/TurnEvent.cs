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

        public static TurnEvent Create(EventType eventType, Position originalPosition = null, Position newPosition = null) => new TurnEvent(eventType, originalPosition, newPosition);

        private TurnEvent(EventType eventType, Position originalPosition, Position newPosition)
        {
            EventType = eventType;
            OriginalPosition = originalPosition;
            NewPosition = newPosition;
        }
    }
}
