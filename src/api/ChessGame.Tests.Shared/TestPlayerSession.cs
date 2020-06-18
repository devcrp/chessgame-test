using ChessGame.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Tests.Shared
{
    public class TestPlayerSession : IPlayerSession
    {
        public TestPlayerSession(Guid? sessionPlayerId)
        {
            PlayerId = sessionPlayerId;
        }

        public Guid? PlayerId { get; set; }
    }
}
