using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Events
{
    public class PieceMovedEventHandler
    {
        private readonly Game _game;

        public static PieceMovedEventHandler Create(Game game) => new PieceMovedEventHandler(game);

        private PieceMovedEventHandler(Game game)
        {
            this._game = game;
        }

        public void Handle(PieceMovement pieceMovement)
        {
            Player player = pieceMovement.Piece.Color == PieceColor.White ? _game.WhitesPlayer : _game.BlacksPlayer;
            player.LogMove(pieceMovement);
            player.AddEventToLog(TurnEvent.Create(EventType.Moved,
                                              Position.Create(pieceMovement.From.Id),
                                              Position.Create(pieceMovement.To.Id)));

            _game.SwitchTurn();
        }
    }
}
