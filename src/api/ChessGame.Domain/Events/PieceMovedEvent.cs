using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Events.Interfaces;
using ChessGame.Domain.ValueObjects;
using ChessGame.Domain.ValueObjects.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Events
{
    public class PieceMovedEvent : IDomainEvent
    {
        public PieceMovedEvent(IPiece sender, PieceMovedEventArguments arguments)
        {
            Sender = sender;
            Arguments = arguments;
        }

        public IPiece Sender { get; }
        public PieceMovedEventArguments Arguments { get; }
    }

    public class PieceMovedEventArguments
    {
        public PieceMovedEventArguments(IPiece piece, Position originalPosition, Position currentPosition, MoveResult result)
        {
            Piece = piece;
            OriginalPosition = originalPosition;
            CurrentPosition = currentPosition;
            Result = result;
        }

        public IPiece Piece { get; internal set; }
        public Position OriginalPosition { get; internal set; }
        public Position CurrentPosition { get; internal set; }
        public MoveResult Result { get; }
    }
}
