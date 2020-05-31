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
        private Board(Game game)
        {
            Game = game;
            Size = new Size(8, 8);
        }

        public Size Size { get; }

        public Game Game { get; }

        public List<IPiece> GetPieces() => Game.WhitesPlayer.Pieces.Union(Game.BlacksPlayer.Pieces).ToList();

        public static Board MountBoard(Game game)
        {
            return new Board(game).SetUp();
        }

        private Board SetUp()
        {
            for (int i = 1; i <= Size.Width; i++)
            {
                AddWhitePiece(new Pawn(new Position(i, 2), this));
                AddBlackPiece(new Pawn(new Position(i, 7), this));
            }

            AddWhitePiece(new Rook(new Position("A", 1), this));
            AddWhitePiece(new Rook(new Position("H", 1), this));
            AddBlackPiece(new Rook(new Position("A", 8), this));
            AddBlackPiece(new Rook(new Position("H", 8), this));

            AddWhitePiece(new Knight(new Position("B", 1), this));
            AddWhitePiece(new Knight(new Position("G", 1), this));
            AddBlackPiece(new Knight(new Position("B", 8), this));
            AddBlackPiece(new Knight(new Position("G", 8), this));

            AddWhitePiece(new Bishop(new Position("C", 1), this));
            AddWhitePiece(new Bishop(new Position("F", 1), this));
            AddBlackPiece(new Bishop(new Position("C", 8), this));
            AddBlackPiece(new Bishop(new Position("F", 8), this));

            AddWhitePiece(new Queen(new Position("D", 1), this));
            AddBlackPiece(new Queen(new Position("D", 8), this));

            AddWhitePiece(new King(new Position("E", 1), this));
            AddBlackPiece(new King(new Position("E", 8), this));

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
