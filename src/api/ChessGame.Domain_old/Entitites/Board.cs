﻿using ChessGame.Domain.Entitites.Interfaces;
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

        public List<Position> GetPositionsInBetween(Position from, Position to)
        {
            List<Position> positions = new List<Position>();

            if (from.VPos == to.VPos && from.HPos != to.HPos)
            {
                for (int i = from.HPos + 1; i < to.HPos; i++)
                {
                    positions.Add(new Position(i, from.VPos));
                }
            }
            else if (from.HPos == to.HPos && from.VPos != to.VPos)
            {
                for (int i = from.VPos + 1; i < to.VPos; i++)
                {
                    positions.Add(new Position(from.HPos, i));
                }
            }
            else if (from.HPos != to.HPos && from.VPos != to.VPos
                     && Math.Abs(from.VPos - to.VPos) == Math.Abs(from.HPos - to.HPos))
            {
                Position p = Position.Clone(from);
                int hIncr = from.HPos < to.HPos ? 1 : -1;
                int vIncr = from.VPos < to.VPos ? 1 : -1;

                do
                {
                    p.HPos += hIncr;
                    p.VPos += vIncr;

                    if (p.Key == to.Key)
                        break;

                    positions.Add(Position.Clone(p));
                }
                while (p.Key != to.Key);
            }

            return positions;
        }

        public List<IPiece> GetPiecesBetween(Position from, Position to)
        {
            List<IPiece> result = new List<IPiece>();
            List<IPiece> allPieces = GetPieces();

            IEnumerable<string> positionsInBetween = GetPositionsInBetween(from, to).Select(x => x.Key);
            return allPieces.Where(piece => positionsInBetween.Contains(piece.Position.Key)).ToList();
        }

        internal void ReMountBoard(List<IPiece> pieces)
        {
            this.Game.WhitesPlayer.Pieces.Clear();
            this.Game.BlacksPlayer.Pieces.Clear();

            foreach (IPiece piece in pieces)
            {
                if (piece.Color == Color.White)
                    AddWhitePiece(piece);
                else
                    AddBlackPiece(piece);
            }
        }

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