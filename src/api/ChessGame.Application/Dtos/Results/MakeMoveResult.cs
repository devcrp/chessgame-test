using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Application.Dtos.Results
{
    public class MakeMoveResult
    {
        internal static MakeMoveResult CreateSuccessResult(List<TurnEvent> turnEvents) => new MakeMoveResult(true, turnEvents);
        internal static MakeMoveResult CreateFailedResult(string failReason) => new MakeMoveResult(false, failReason);

        private MakeMoveResult(bool success, string failReason)
        {
            Success = success;
            FailReason = failReason;
        }

        private MakeMoveResult(bool success, List<TurnEvent> turnEvents)
        {
            Success = success;
            TurnEvents = turnEvents;
        }

        public bool Success { get; }
        public string FailReason { get; set; }
        public List<TurnEvent> TurnEvents { get; }
    }
}
