using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Events.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Events
{
    public class PieceMovedEvent : IDomainEvent
    {
        public PieceMovedEvent(object sender, PieceMovedEventArguments arguments)
        {
            Sender = sender;
            Arguments = arguments;
        }

        public object Sender { get; }
        public PieceMovedEventArguments Arguments { get; }
    }

    public class PieceMovedEventArguments
    {
        public PieceMovedEventArguments(IPiece piece, Position originalPosition, Position currentPosition)
        {
            Piece = piece;
            OriginalPosition = originalPosition;
            CurrentPosition = currentPosition;
        }

        public IPiece Piece { get; internal set; }
        public Position OriginalPosition { get; internal set; }
        public Position CurrentPosition { get; internal set; }
    }
}
