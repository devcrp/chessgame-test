using ChessGame.Domain.Events;
using ChessGame.Domain.Services;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; }
        public string ExternalIdentifier { get; set; }
        public DateTime StartedTimeUtc { get; set; }
        public DateTime? FinishedTimeUtc { get; set; }
        public bool IsOver => FinishedTimeUtc.HasValue;
        public Board Board { get; }
        public Player WhitesPlayer { get; private set; }
        public Player BlacksPlayer { get; private set; }
        public Player CurrentTurnPlayer { get; private set; }
        public Player Winner { get; private set; }
        public bool CanStart => WhitesPlayer != null && BlacksPlayer != null;

        public static Game PrepareGame() => new Game(startAsEmpty: false);

        public static Game StartNewGame(string whitesPlayerName, string blacksPlayerName)
        {
            Game game = new Game(startAsEmpty: false);
            game.AddPlayer(whitesPlayerName);
            game.AddPlayer(blacksPlayerName);
            return game;
        }

        public static Game StartEmptyGame(string whitesPlayerName, string blacksPlayerName)
        {
            Game game = new Game(startAsEmpty: true);
            game.AddPlayer(whitesPlayerName);
            game.AddPlayer(blacksPlayerName);
            return game;
        }

        private Game(bool startAsEmpty)
        {
            Id = Guid.NewGuid();
            ExternalIdentifier = ExternalIdentifierGenerator.GetRandomHexNumber(8);
            Board = startAsEmpty ? Board.Create() : Board.CreateAndSetup();
            StartedTimeUtc = DateTime.UtcNow;

            Board.TurnEnded += TurnEndedEventHandler.Create(this).Handle;
        }

        public Guid? AddPlayer(string playerName) => AddPlayer(Guid.NewGuid(), playerName);

        public Guid? AddPlayer(Guid playerId, string playerName)
        {
            if (WhitesPlayer == null)
            {
                WhitesPlayer = Player.Create(playerId, playerName, PieceColor.White);
                CurrentTurnPlayer = WhitesPlayer;
                return WhitesPlayer.Id;
            }
            else if (BlacksPlayer == null)
            {
                BlacksPlayer = Player.Create(playerId, playerName, PieceColor.Black);
                return BlacksPlayer.Id;
            }

            return null;
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
