using ChessGame.Domain.Entitites;
using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces;
using ChessGame.Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Application.Test
{
    public class RookTests
    {
        Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
            _game.Start("Carlos", "Marta");
        }

        [Test]
        public void MoveRook_Should_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Rook(Position.Parse("A1"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("A2")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("A3")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("A4")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("A5")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("A6")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("A7")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("A8")).IsSuccessful);

            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("B1")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("C1")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("D1")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("E1")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("F1")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("G1")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("H1")).IsSuccessful);
        }

        [Test]
        public void MoveRook_To_Castling_Should_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Rook(Position.Parse("H1"), _game.Board) { Color = Color.White });
            pieces.Add(new King(Position.Parse("E1"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("E1"), pieces.Last()).IsSuccessful);
        }

        [Test]
        public void MoveRook_To_Kill_Self_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Rook(Position.Parse("A1"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("A2"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("A2"), pieces.Last()).IsSuccessful);
        }

        [Test]
        public void MoveRook_With_Pieces_InBetween_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Rook(Position.Parse("A1"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("A2"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("A8"), null, new List<IPiece> { pieces.Last() }).IsSuccessful);
        }

        [Test]
        public void MoveRook_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Rook(Position.Parse("A1"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("A1")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("B2")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("C3")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("D4")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("E5")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("F6")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("G7")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("H8")).IsSuccessful);
        }
    }
}
