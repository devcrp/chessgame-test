using ChessGame.Domain.EventHandlers.Base;
using ChessGame.Domain.Entities;
using ChessGame.Domain.Entitites;
using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Events;
using ChessGame.Domain.Events.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.EventHandlers
{
    public class PieceMovedEventHandler : Handler<PieceMovedEvent>, IDomainEventHandler
    {
        private PieceMovedEventHandler()
        {
        }

        public void Handle(object e)
        {
            PieceMovedEvent @event = GetEvent(e);

            Game game = @event.Sender.Board.Game;

            Turn currentTurn = game.GetCurrentTurn();
            if (@event.Arguments.Result.KilledPiece != null)
            {
                Player oponent = currentTurn.GetOponent();
                oponent.KillPiece(@event.Arguments.Result.KilledPiece);
            }

            currentTurn.RecordMovement(new Movement(@event.Arguments.Piece, @event.Arguments.OriginalPosition, @event.Arguments.CurrentPosition));

            game.SwitchTurn();
        }

        public static PieceMovedEventHandler Create()
        {
            return new PieceMovedEventHandler();
        }
    }
}
