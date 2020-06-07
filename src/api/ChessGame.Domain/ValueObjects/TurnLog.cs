using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects
{
    public class TurnLog
    {
        public PieceMovement PieceMovement { get; private set; }

        public static TurnLog Create(PieceMovement pieceMovement)
        {
            return new TurnLog(pieceMovement);
        }

        private TurnLog(PieceMovement pieceMovement)
        {
            PieceMovement = pieceMovement;
        }
    }
}
