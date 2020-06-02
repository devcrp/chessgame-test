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
using ChessGame.Domain.Entitites.Pieces;

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

            if (@event.Arguments.Result.SwappedPiece != null
                && @event.Sender.GetType() == typeof(King) && @event.Arguments.Result.SwappedPiece.GetType() == typeof(Rook))
            {
                Position newRookPosition = new Position(@event.Arguments.OriginalPosition.HPos + 1, @event.Arguments.OriginalPosition.VPos);
                Position newKingPosition = new Position(@event.Arguments.Result.SwappedPiece.Position.HPos - 1, @event.Arguments.Result.SwappedPiece.Position.VPos);
                @event.Arguments.Result.SwappedPiece.SideEffectMove(newRookPosition);
                @event.Sender.SideEffectMove(newKingPosition);
                
                game.SwitchTurn();
                return;
            }

            currentTurn.RecordMovement(new Movement(@event.Arguments.Piece, @event.Arguments.OriginalPosition, @event.Arguments.CurrentPosition));
            @event.Sender.NumberOfMoves++;

            game.SwitchTurn();
        }

        public static PieceMovedEventHandler Create()
        {
            return new PieceMovedEventHandler();
        }
    }
}
