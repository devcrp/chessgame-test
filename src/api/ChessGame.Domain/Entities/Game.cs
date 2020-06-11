using ChessGame.Domain.Events;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; }
        public DateTime StartedTimeUtc { get; set; }
        public DateTime? FinishedTimeUtc { get; set; }
        public bool IsOver => FinishedTimeUtc.HasValue;
        public Board Board { get; }
        public Player WhitesPlayer { get; }
        public Player BlacksPlayer { get; }
        public Player CurrentTurnPlayer { get; private set; }
        public Player Winner { get; private set; }

        public static Game StartNewGame(string whitesPlayerName, string blacksPlayerName)
        {
            return new Game(whitesPlayerName, blacksPlayerName, startAsEmpty: false);
        }

        public static Game StartEmptyGame(string whitesPlayerName, string blacksPlayerName)
        {
            return new Game(whitesPlayerName, blacksPlayerName, startAsEmpty: true);
        }

        private Game(string whitesPlayerName, string blacksPlayerName, bool startAsEmpty)
        {
            Id = Guid.NewGuid();
            Board = startAsEmpty ? Board.Create() : Board.CreateAndSetup();
            WhitesPlayer = Player.Create(whitesPlayerName, PieceColor.White);
            BlacksPlayer = Player.Create(blacksPlayerName, PieceColor.Black);
            CurrentTurnPlayer = WhitesPlayer;
            StartedTimeUtc = DateTime.UtcNow;

            Board.TurnEnded += TurnEndedEventHandler.Create(this).Handle;
        }

        public void SwitchTurn()
        {
            CurrentTurnPlayer = CurrentTurnPlayer.Equals(WhitesPlayer) ? BlacksPlayer : WhitesPlayer;
        }

        public void GameOver(Player winner)
        {
            Winner = winner;
            FinishedTimeUtc = DateTime.UtcNow;
        }
    }
}
