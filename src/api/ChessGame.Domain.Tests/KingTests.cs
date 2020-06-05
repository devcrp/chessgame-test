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
    public class KingTests
    {
        Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
            _game.Start("Carlos", "Marta");
        }

        [Test]
        public void MoveKing_Should_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new King(Position.Parse("E1"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("D1")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("D2")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("E2")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("F2")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("F1")).IsSuccessful);
        }

        [Test]
        public void MoveKing_To_Castling_Should_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new King(Position.Parse("E1"), _game.Board) { Color = Color.White });
            pieces.Add(new Rook(Position.Parse("H1"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("H1")).IsSuccessful);
        }

        [Test]
        public void MoveKing_To_Kill_Self_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new King(Position.Parse("E1"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("E2"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("E2")).IsSuccessful);
        }

        [Test]
        public void MoveKing_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new King(Position.Parse("E1"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("E1")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("D3")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("B3")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("H1")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("G2")).IsSuccessful);
        }
    }
}
