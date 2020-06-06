using ChessGame.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Tests
{
    public class BoardTests
    {
        [Test]
        public void CreateAndSetupBoard_Should_Init_With_64_Squares()
        {
            Board board = Board.CreateAndSetup();
            Assert.AreEqual(64, board.Squares.Count);
        }

        [Test]
        public void CreateAndSetupBoard_Should_Init_With_32_Pieces()
        {
            Board board = Board.CreateAndSetup();
            Assert.AreEqual(32, board.Pieces.Count);
        }
    }
}
