using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces;
using ChessGame.Domain.Entitites.Pieces.Base;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Entitites
{
    public class Board
    {
        public Board(Game game)
        {
            Game = game;
            Size = new Size(8, 8);
        }

        public Size Size { get; }

        public Game Game { get; }

        public List<IPiece> GetPieces() => Game.WhitesPlayer.Pieces.Union(Game.BlacksPlayer.Pieces).ToList();

        public Board SetUp()
        {
            for (int i = 1; i <= Size.Width; i++)
            {
                AddWhitePiece(new Pawn(new Position(i, 2)));
                AddBlackPiece(new Pawn(new Position(i, 7)));
            }

            AddWhitePiece(new Rook(new Position("A", 1)));
            AddWhitePiece(new Rook(new Position("H", 1)));
            AddBlackPiece(new Rook(new Position("A", 8)));
            AddBlackPiece(new Rook(new Position("H", 8)));

            AddWhitePiece(new Knight(new Position("B", 1)));
            AddWhitePiece(new Knight(new Position("G", 1)));
            AddBlackPiece(new Knight(new Position("B", 8)));
            AddBlackPiece(new Knight(new Position("G", 8)));

            AddWhitePiece(new Bishop(new Position("C", 1)));
            AddWhitePiece(new Bishop(new Position("F", 1)));
            AddBlackPiece(new Bishop(new Position("C", 8)));
            AddBlackPiece(new Bishop(new Position("F", 8)));

            AddWhitePiece(new Queen(new Position("D", 1)));
            AddBlackPiece(new Queen(new Position("D", 8)));

            AddWhitePiece(new King(new Position("E", 1)));
            AddBlackPiece(new King(new Position("E", 8)));

            return this;
        }

        private void AddWhitePiece(IPiece piece)
        {
            piece.Color = Color.White;
            Game.WhitesPlayer.Pieces.Add(piece);
        }

        private void AddBlackPiece(IPiece piece)
        {
            piece.Color = Color.Black;
            Game.BlacksPlayer.Pieces.Add(piece);
        }
    }
}
