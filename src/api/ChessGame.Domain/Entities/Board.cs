using ChessGame.Domain.Services;
using ChessGame.Domain.ValueObjects;
using ChessGame.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChessGame.Domain.Specifications.Composites;
using ChessGame.Domain.Specifications.Movements;

namespace ChessGame.Domain.Entities
{
    public class Board
    {
        public List<Square> Squares { get; private set; }
        public List<Piece> Pieces => Squares.Where(square => !square.IsEmpty).Select(square => square.Piece).ToList();

        public static Board Create() => new Board();
        public static Board CreateAndSetup() => new Board(setupPieces: true);

        private Board(bool setupPieces = false)
        {
            InitSquares();
            if (setupPieces)
                SetupPieces();
        }

        private void InitSquares()
        {
            Squares = new List<Square>();
            for(int i = 1; i <= 8; i++)
            {
                for (int i2 = 1; i2 <= 8; i2++)
                {
                    Squares.Add(Square.Create(i, i2));
                }
            }
        }

        private void SetupPieces()
        {
            for (int i = 1; i <= 8; i++)
            {
                AddPiece(Piece.Create(PieceType.Pawn, PieceColor.White), Position.ToIdentifier(i, 2));
                AddPiece(Piece.Create(PieceType.Pawn, PieceColor.Black), Position.ToIdentifier(i, 7));
            }

            AddPiece(Piece.Create(PieceType.Rook, PieceColor.White), "A1");
            AddPiece(Piece.Create(PieceType.Rook, PieceColor.White), "H1");
            AddPiece(Piece.Create(PieceType.Rook, PieceColor.Black), "A8");
            AddPiece(Piece.Create(PieceType.Rook, PieceColor.Black), "H8");

            AddPiece(Piece.Create(PieceType.Knight, PieceColor.White), "B1");
            AddPiece(Piece.Create(PieceType.Knight, PieceColor.White), "G1");
            AddPiece(Piece.Create(PieceType.Knight, PieceColor.Black), "B8");
            AddPiece(Piece.Create(PieceType.Knight, PieceColor.Black), "G8");

            AddPiece(Piece.Create(PieceType.Bishop, PieceColor.White), "C1");
            AddPiece(Piece.Create(PieceType.Bishop, PieceColor.White), "F1");
            AddPiece(Piece.Create(PieceType.Bishop, PieceColor.Black), "C8");
            AddPiece(Piece.Create(PieceType.Bishop, PieceColor.Black), "F8");

            AddPiece(Piece.Create(PieceType.Queen, PieceColor.White), "D1");
            AddPiece(Piece.Create(PieceType.Queen, PieceColor.Black), "D8");

            AddPiece(Piece.Create(PieceType.King, PieceColor.White), "E1");
            AddPiece(Piece.Create(PieceType.King, PieceColor.Black), "E8");
        }

        private void MovePiece(PieceMovement pieceMovement)
        {
            Square originSquare = GetSquare(pieceMovement.Piece);
            Square destinationSquare = GetSquare(pieceMovement.To.Id);

            destinationSquare.LandPiece(pieceMovement.Piece);
            originSquare.RemovePiece();

            pieceMovement.Piece.Moved();
        }

        public Square GetSquare(string squareId) => Squares.Single(square => square.Position.Id == squareId);
        public Square GetSquare(Piece piece) => Squares.Single(square => !square.IsEmpty && square.Piece.Equals(piece));

        public void AddPiece(Piece piece, string squareId)
        {
            Square square = GetSquare(squareId);
            square.LandPiece(piece);
        }

        public bool HandleMove(PieceMovement pieceMovement)
        {
            if (!CanBeMovedToRequestedPosition(pieceMovement))
                return false;

            Square destinationSquare = GetSquare(pieceMovement.To.Id);
            Piece removedPiece = null;
            if (!destinationSquare.IsEmpty)
            {
                removedPiece = destinationSquare.RemovePiece();
            }

            MovePiece(pieceMovement);

            PieceMoved?.Invoke(pieceMovement);
            if (removedPiece != null)
                PieceCaptured?.Invoke(pieceMovement, removedPiece);

            return true;
        }

        private bool CanBeMovedToRequestedPosition(PieceMovement pieceMovement)
        {
            LegalMovementSpecification legalMovementspecification = LegalMovementSpecification.Create(this);
            if (!legalMovementspecification.IsSatisfied(pieceMovement))
                return false;

            if (!pieceMovement.Piece.CanJump)
            {
                JumperMovementSpecification jumperMovementSpecification = JumperMovementSpecification.Create(this);
                if (jumperMovementSpecification.IsSatisfied(pieceMovement))
                    return false;
            }

            return true;
        }

        public delegate void PieceMovedEventHandler(PieceMovement pieceMovement);
        public event PieceMovedEventHandler PieceMoved;

        public delegate void PieceCapturedEventHandler(PieceMovement pieceMovement, Piece removedPiece);
        public event PieceCapturedEventHandler PieceCaptured;
    }
}
