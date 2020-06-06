using ChessGame.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Tests
{
    public class GameTests
    {
        [Test]
        public void StartNewGame_Should_Initialize_Two_Players()
        {
            Game game = Game.StartNewGame("Carlos", "Marta");
            Assert.IsNotNull(game.WhitesPlayer);
            Assert.IsNotNull(game.BlacksPlayer);
            Assert.AreEqual("Carlos", game.WhitesPlayer.Name);
            Assert.AreEqual("Marta", game.BlacksPlayer.Name);
        }

        [Test]
        public void StartNewGame_Should_Set_CurrentTurnPlayer_To_Whites()
        {
            Game game = Game.StartNewGame("Carlos", "Marta");
            Assert.AreEqual(game.CurrentTurnPlayer, game.WhitesPlayer);
        }
    }
}
