using ChessGame.Application.EventHandlers.Base;
using ChessGame.Domain.Entities;
using ChessGame.Domain.Entitites;
using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Events;
using ChessGame.Domain.Events.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Application.EventHandlers
{
    public class PieceMovedEventHandler : Handler<PieceMovedEvent>, IDomainEventHandler
    {
        private readonly Game _game;

        private PieceMovedEventHandler(Game game)
        {
            this._game = game;
        }

        public void Handle(object e)
        {
            PieceMovedEvent @event = GetEvent(e);

            Turn currentTurn = _game.GetCurrentTurn();
            if (@event.Arguments.PieceKilled != null)
            {
                Player oponent = currentTurn.GetOponent();
                oponent.KillPiece(@event.Arguments.PieceKilled);
            }

            currentTurn.RecordMovement(new Movement(@event.Arguments.Piece, @event.Arguments.OriginalPosition, @event.Arguments.CurrentPosition));

            _game.SwitchTurn();
        }

        public static PieceMovedEventHandler Create(Game game)
        {
            return new PieceMovedEventHandler(game);
        }
    }
}
