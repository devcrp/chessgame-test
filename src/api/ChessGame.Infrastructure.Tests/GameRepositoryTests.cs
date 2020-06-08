using ChessGame.Domain.Entities;
using ChessGame.Infrastructure.Repositories;
using NUnit.Framework;
using System;

namespace ChessGame.Infrastructure.Tests
{
    public class Tests
    {
        [Test]
        public void Insert_Game_Should_Persist_Game()
        {
            GameRepository gameRepository = new GameRepository();

            Guid gameId = gameRepository.Insert(Game.StartNewGame("Player 1", "Player 2"));

            Assert.AreNotEqual(Guid.Empty, gameId);
            Assert.IsNotNull(gameRepository.Get(gameId));
        }
    }
}