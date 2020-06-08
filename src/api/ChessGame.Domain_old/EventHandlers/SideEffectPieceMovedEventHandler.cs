using ChessGame.Domain.Entities;
using ChessGame.Domain.Entitites;
using ChessGame.Domain.EventHandlers.Base;
using ChessGame.Domain.Events;
using ChessGame.Domain.Events.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.EventHandlers
{
    public class SideEffectPieceMovedEventHandler : Handler<SideEffectPieceMovedEvent>, IDomainEventHandler
    {
        private SideEffectPieceMovedEventHandler()
        {
        }

        public void Handle(object e)
        {
            SideEffectPieceMovedEvent @event = GetEvent(e);

            Game game = @event.Sender.Board.Game;
            Turn currentTurn = game.GetCurrentTurn();

            currentTurn.RecordMovement(new Movement(@event.Arguments.Piece, @event.Arguments.OriginalPosition, @event.Arguments.CurrentPosition));
            @event.Sender.NumberOfMoves++;
        }

        public static SideEffectPieceMovedEventHandler Create()
        {
            return new SideEffectPieceMovedEventHandler();
        }
    }
}
