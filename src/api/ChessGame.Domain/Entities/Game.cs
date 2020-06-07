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
        public Board Board { get; }
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
            Board = Board.CreateAndSetup();
            WhitesPlayer = Player.Create(whitesPlayerName, PieceColor.White);
            BlacksPlayer = Player.Create(blacksPlayerName, PieceColor.Black);
            CurrentTurnPlayer = WhitesPlayer;

            Board.PieceMoved += PieceMovedEventHandler.Create(this).Handle;
        }

        public void SwitchTurn()
        {
            CurrentTurnPlayer = CurrentTurnPlayer.Equals(WhitesPlayer) ? BlacksPlayer : WhitesPlayer;
        }
    }
}
