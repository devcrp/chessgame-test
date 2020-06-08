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
    public class QueenTests
    {
        Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
            _game.Start("Carlos", "Marta");
        }

        [Test]
        public void MoveQueen_Should_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Queen(Position.Parse("D1"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("A1")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("H1")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("A4")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("H5")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("D8")).IsSuccessful);
        }

        [Test]
        public void MoveQueen_To_Kill_Self_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Queen(Position.Parse("D1"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("H5"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("H5")).IsSuccessful);
        }

        [Test]
        public void MoveQueen_With_Pieces_InBetween_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Queen(Position.Parse("D1"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("E2"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("A8")).IsSuccessful);
        }

        [Test]
        public void MoveQueen_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Queen(Position.Parse("D1"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("B2")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("A2")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("H4")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("F4")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("A8")).IsSuccessful);
        }
    }
}
