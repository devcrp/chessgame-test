using ChessGame.Domain.Entitites;
using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces;
using ChessGame.Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Tests
{
    public class BishopTests
    {
        Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
            _game.Start("Carlos", "Marta");
        }

        [Test]
        public void MoveBishop_Should_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Bishop(Position.Parse("C1"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("D2")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("E3")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("F4")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("G5")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("H6")).IsSuccessful);

            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("B2")).IsSuccessful);
        }

        [Test]
        public void MoveBishop_To_Kill_Self_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Bishop(Position.Parse("A1"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("D2"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("D2")).IsSuccessful);
        }

        [Test]
        public void MoveBishop_With_Pieces_InBetween_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Bishop(Position.Parse("C1"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("D2"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("E3")).IsSuccessful);
        }

        [Test]
        public void MoveBishop_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Bishop(Position.Parse("C1"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("B1")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("D1")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("C2")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("C1")).IsSuccessful);
        }
    }
}
