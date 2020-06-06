using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Entities
{
    public class Board
    {
        public List<Square> Squares { get; private set; }
        public List<Piece> Pieces { get; private set; }

        public static Board Create() => new Board();
        public static Board CreateAndSetup() => new Board(setup: true);

        private Board(bool setup = false)
        {
            if (setup)
                Setup();
        }

        private void Setup()
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
        }

        private Square GetSquare(string id) => Squares.Single(square => square.Id == id);

        public void AddPiece(Piece piece, string squareId)
        {
            Square square = GetSquare(squareId);
            square.LandPiece(piece);
        }
    }
}
