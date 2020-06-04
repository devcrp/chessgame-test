using ChessGame.Application.Services;
using ChessGame.Domain.Entitites;
using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces;
using ChessGame.Domain.ValueObjects;
using ChessGame.Infrastructure.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Application.Test
{
    public class PawnTests
    {
        Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
            _game.Start("Carlos", "Marta");
        }

        [Test]
        public void MovePawn_Should_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Pawn(Position.Parse("B2"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("B3")).IsSuccessful);
            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("B4")).IsSuccessful);
        }

        [Test]
        public void MovePawn_To_Kill_Should_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Pawn(Position.Parse("B2"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("A3"), _game.Board) { Color = Color.Black });
            _game.ReMountBoard(pieces);

            Assert.IsTrue(pieces.First().IsPositionAllowed(Position.Parse("A3"), pieces.Last()).IsSuccessful);
        }

        [Test]
        public void MovePawn_To_Kill_Self_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Pawn(Position.Parse("B2"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("A3"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("A3"), pieces.Last()).IsSuccessful);
        }

        [Test]
        public void MovePawn_With_Pieces_InBetween_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Pawn(Position.Parse("B2"), _game.Board) { Color = Color.White });
            pieces.Add(new Pawn(Position.Parse("B3"), _game.Board) { Color = Color.Black });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("B4"), null, new List<IPiece> { pieces.Last() }).IsSuccessful);
        }

        [Test]
        public void MovePawn_Should_Not_Be_Allowed()
        {
            List<IPiece> pieces = new List<IPiece>();
            pieces.Add(new Pawn(Position.Parse("B2"), _game.Board) { Color = Color.White });
            _game.ReMountBoard(pieces);

            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("B2")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("B5")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("A2")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("A3")).IsSuccessful);
            Assert.IsFalse(pieces.First().IsPositionAllowed(Position.Parse("A4")).IsSuccessful);
        }
    }
}
