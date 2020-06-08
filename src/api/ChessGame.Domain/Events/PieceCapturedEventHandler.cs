using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Events
{
    public class PieceCapturedEventHandler
    {
        private readonly Game _game;

        public static PieceCapturedEventHandler Create(Game game) => new PieceCapturedEventHandler(game);

        private PieceCapturedEventHandler(Game game)
        {
            this._game = game;
        }

        public void Handle(PieceMovement pieceMovement, Piece removedPiece)
        {
            Player player = pieceMovement.Piece.Color == PieceColor.White ? _game.WhitesPlayer : _game.BlacksPlayer;
            player.AddEventToLog(TurnEvent.Create(EventType.Captured, Position.Create(pieceMovement.To.Id)));
        }
    }
}
