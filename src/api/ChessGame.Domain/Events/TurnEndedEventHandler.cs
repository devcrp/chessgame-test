using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Events
{
    public class TurnEndedEventHandler
    {
        private readonly Game _game;

        public static TurnEndedEventHandler Create(Game game) => new TurnEndedEventHandler(game);

        private TurnEndedEventHandler(Game game)
        {
            this._game = game;
        }

        public void Handle(TurnLog turnLog)
        {
            _game.CurrentTurnPlayer.LogMove(turnLog);

            if (turnLog.TurnEvents.Any(@event => @event.EventType == EventType.GameOver))
            {
                _game.GameOver(_game.CurrentTurnPlayer);
            }
            else
            {
                _game.SwitchTurn();
            }
        }
    }
}
