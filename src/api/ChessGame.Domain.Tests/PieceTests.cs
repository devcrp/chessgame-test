using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Tests
{
    public class PieceTests
    {
        [Test]
        public void Move_Piece_Should_Flag_It_As_Moved()
        {
            Piece piece = Piece.Create(PieceType.Pawn, PieceColor.White);
            piece.Moved();
            Assert.IsTrue(piece.HasMoved);
        }
    }
}
