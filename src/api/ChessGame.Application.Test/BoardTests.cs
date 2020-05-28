using ChessGame.Application.Services;
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
    public class BoardTests
    {
        GameService _gameService;

        [SetUp]
        public void SetUp()
        {
            _gameService = new GameService(new GameRepository());
        }

        [Test]
        public void SetUp_After_StartGame_Should_Add_Pieces_To_Correct_Positions()
        {
            Guid gameId = _gameService.StartNewGame("Carlos", "Marta");
            ChessGame.Domain.Entitites.Game game = _gameService.GetGame(gameId);
            List<IPiece> allPieces = game.Board.GetPieces();

            #region Empty

            Assert.IsTrue(EmptyIn(allPieces, "A3"));
            Assert.IsTrue(EmptyIn(allPieces, "B3"));
            Assert.IsTrue(EmptyIn(allPieces, "C3"));
            Assert.IsTrue(EmptyIn(allPieces, "D3"));
            Assert.IsTrue(EmptyIn(allPieces, "E3"));
            Assert.IsTrue(EmptyIn(allPieces, "F3"));
            Assert.IsTrue(EmptyIn(allPieces, "G3"));
            Assert.IsTrue(EmptyIn(allPieces, "H3"));

            Assert.IsTrue(EmptyIn(allPieces, "A4"));
            Assert.IsTrue(EmptyIn(allPieces, "B4"));
            Assert.IsTrue(EmptyIn(allPieces, "C4"));
            Assert.IsTrue(EmptyIn(allPieces, "D4"));
            Assert.IsTrue(EmptyIn(allPieces, "E4"));
            Assert.IsTrue(EmptyIn(allPieces, "F4"));
            Assert.IsTrue(EmptyIn(allPieces, "G4"));
            Assert.IsTrue(EmptyIn(allPieces, "H4"));

            Assert.IsTrue(EmptyIn(allPieces, "A5"));
            Assert.IsTrue(EmptyIn(allPieces, "B5"));
            Assert.IsTrue(EmptyIn(allPieces, "C5"));
            Assert.IsTrue(EmptyIn(allPieces, "D5"));
            Assert.IsTrue(EmptyIn(allPieces, "E5"));
            Assert.IsTrue(EmptyIn(allPieces, "F5"));
            Assert.IsTrue(EmptyIn(allPieces, "G5"));
            Assert.IsTrue(EmptyIn(allPieces, "H5"));

            Assert.IsTrue(EmptyIn(allPieces, "A6"));
            Assert.IsTrue(EmptyIn(allPieces, "B6"));
            Assert.IsTrue(EmptyIn(allPieces, "C6"));
            Assert.IsTrue(EmptyIn(allPieces, "D6"));
            Assert.IsTrue(EmptyIn(allPieces, "E6"));
            Assert.IsTrue(EmptyIn(allPieces, "F6"));
            Assert.IsTrue(EmptyIn(allPieces, "G6"));
            Assert.IsTrue(EmptyIn(allPieces, "H6"));

            #endregion Empty

            #region Pawns

            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "A2", Color.White));
            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "B2", Color.White));
            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "C2", Color.White));
            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "D2", Color.White));
            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "E2", Color.White));
            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "F2", Color.White));
            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "G2", Color.White));
            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "H2", Color.White));

            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "A7", Color.Black));
            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "B7", Color.Black));
            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "C7", Color.Black));
            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "D7", Color.Black));
            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "E7", Color.Black));
            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "F7", Color.Black));
            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "G7", Color.Black));
            Assert.IsTrue(PieceIsIn<Pawn>(allPieces, "H7", Color.Black));

            #endregion Pawns

            Assert.IsTrue(PieceIsIn<Rook>(allPieces, "A1", Color.White));
            Assert.IsTrue(PieceIsIn<Rook>(allPieces, "H1", Color.White));
            Assert.IsTrue(PieceIsIn<Rook>(allPieces, "A8", Color.Black));
            Assert.IsTrue(PieceIsIn<Rook>(allPieces, "H8", Color.Black));

            Assert.IsTrue(PieceIsIn<Knight>(allPieces, "B1", Color.White));
            Assert.IsTrue(PieceIsIn<Knight>(allPieces, "G1", Color.White));
            Assert.IsTrue(PieceIsIn<Knight>(allPieces, "B8", Color.Black));
            Assert.IsTrue(PieceIsIn<Knight>(allPieces, "G8", Color.Black));

            Assert.IsTrue(PieceIsIn<Bishop>(allPieces, "C1", Color.White));
            Assert.IsTrue(PieceIsIn<Bishop>(allPieces, "F1", Color.White));
            Assert.IsTrue(PieceIsIn<Bishop>(allPieces, "C8", Color.Black));
            Assert.IsTrue(PieceIsIn<Bishop>(allPieces, "F8", Color.Black));

            Assert.IsTrue(PieceIsIn<King>(allPieces, "E1", Color.White));
            Assert.IsTrue(PieceIsIn<King>(allPieces, "E8", Color.Black));

            Assert.IsTrue(PieceIsIn<Queen>(allPieces, "D1", Color.White));
            Assert.IsTrue(PieceIsIn<Queen>(allPieces, "D8", Color.Black));
        }

        private static bool EmptyIn(List<IPiece> pieces, string positionKey) => !pieces.Any(piece => piece.Position.Key == positionKey);

        private static bool PieceIsIn<T>(List<IPiece> pieces, string positionKey, Color color) where T : IPiece
        {
            IPiece foundPiece = pieces.SingleOrDefault(piece => piece.Color == color && piece.Position.Key == positionKey);
            if (foundPiece == null)
                return false;

            return foundPiece is T;
        }
    }
}
