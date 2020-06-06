using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects
{
    public class TurnLog
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public static TurnLog CreateAndStart()
        {
            return new TurnLog
            {
                StartTime = DateTime.UtcNow
            };
        }

        private TurnLog()
        {

        }

        public void End()
        {
            EndTime = DateTime.UtcNow;
        }
    }
}
