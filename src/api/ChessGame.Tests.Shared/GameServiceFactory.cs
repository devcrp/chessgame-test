using ChessGame.Application.Services;
using ChessGame.Domain.Entities;
using ChessGame.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Tests.Shared
{
    public static class GameServiceFactory
    {
        public static GameService Create(Guid? sessionPlayerId = null) => new GameService(new GameRepository(), new TestPlayerSession(sessionPlayerId));
    }
}
