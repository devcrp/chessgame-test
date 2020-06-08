using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Events.Arguments;
using ChessGame.Domain.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Events
{
    public class SideEffectPieceMovedEvent : IDomainEvent
    {
        public SideEffectPieceMovedEvent(IPiece sender, PieceMovedEventArguments arguments)
        {
            Sender = sender;
            Arguments = arguments;
        }

        public IPiece Sender { get; }
        public PieceMovedEventArguments Arguments { get; }
    }
}
