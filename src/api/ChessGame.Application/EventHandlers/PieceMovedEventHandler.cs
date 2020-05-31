using ChessGame.Application.EventHandlers.Base;
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
        private readonly IPiece _pieceKilled;

        public PieceMovedEventHandler(Game game, IPiece pieceKilled)
        {
            this._game = game;
            this._pieceKilled = pieceKilled;
        }

        public void Handle(object e)
        {
            PieceMovedEvent @event = GetEvent(e);

            Turn currentTurn = _game.GetCurrentTurn();
            if (_pieceKilled != null)
            {
                Player oponent = currentTurn.GetOponent();
                oponent.KillPiece(_pieceKilled);
            }

            currentTurn.RecordMovement(new Movement(@event.Arguments.Piece, @event.Arguments.OriginalPosition, @event.Arguments.CurrentPosition));

            _game.SwitchTurn();
        }
    }
}
