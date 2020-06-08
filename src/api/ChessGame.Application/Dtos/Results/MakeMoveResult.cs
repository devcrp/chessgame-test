using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Application.Dtos.Results
{
    public class MakeMoveResult
    {
        internal static MakeMoveResult CreateSuccessResult(TurnLog turnLog) => new MakeMoveResult(true, turnLog);
        internal static MakeMoveResult CreateFailedResult(string failReason) => new MakeMoveResult(false, failReason);

        private MakeMoveResult(bool success, string failReason)
        {
            Success = success;
            FailReason = failReason;
        }

        private MakeMoveResult(bool success, TurnLog turnLog)
        {
            Success = success;
            TurnLog = turnLog;
        }

        public bool Success { get; }
        public string FailReason { get; set; }
        public TurnLog TurnLog { get; }
    }
}
