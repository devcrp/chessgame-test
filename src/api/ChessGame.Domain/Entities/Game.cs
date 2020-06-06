using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; }
        public Player WhitesPlayer { get; }
        public Player BlacksPlayer { get; }
        public Player CurrentTurnPlayer { get; private set; }

        public static Game StartNewGame(string whitesPlayerName, string blacksPlayerName)
        {
            return new Game(whitesPlayerName, blacksPlayerName);
        }

        private Game(string whitesPlayerName, string blacksPlayerName)
        {
            Id = Guid.NewGuid();
            WhitesPlayer = Player.Create(whitesPlayerName, PieceColor.White);
            BlacksPlayer = Player.Create(blacksPlayerName, PieceColor.Black);
            CurrentTurnPlayer = WhitesPlayer;
        }
    }
}
