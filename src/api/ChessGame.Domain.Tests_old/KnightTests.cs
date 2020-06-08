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
    public class KnightTests
    {
        Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
            _game.Start("Carlos", "Marta");
        }

        [Test]
        public void MoveKnight_Should_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Knight(Position.Parse("B1"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("D2")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("A3")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("C3")).IsSuccessful);
        }

        [Test]
        public void MoveKnight_To_Kill_Self_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Knight(Position.Parse("B1"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("D2"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("D2")).IsSuccessful);
        }

        [Test]
        public void MoveKnight_With_Pieces_InBetween_Should_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Knight(Position.Parse("B1"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("A2"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("B2"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("C2"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("D2"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("E2"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("C3")).IsSuccessful);
        }

        [Test]
        public void MoveKnight_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Knight(Position.Parse("B1"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("B1")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("A1")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("B2")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("D4")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("C1")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("A2")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("C2")).IsSuccessful);
            
        }
    }
}
