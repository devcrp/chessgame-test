using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Entitites
{
    public class Game
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateTime StartedTimeUtc { get; private set; }

        public Board Board { get; private set; }

        public Player WhitesPlayer { get; private set; }

        public Player BlacksPlayer { get; private set; }

        public List<Turn> Turns { get; } = new List<Turn>();

        public OperationResult Start(string whitesPlayerName, string blacksPlayerName)
        {
            if (string.IsNullOrEmpty(whitesPlayerName) || string.IsNullOrEmpty(blacksPlayerName))
                return OperationResult.Fail("Both players must have a name.");

            StartedTimeUtc = DateTime.UtcNow;

            WhitesPlayer = new Player(this, whitesPlayerName);
            BlacksPlayer = new Player(this, blacksPlayerName);

            Board = Board.MountBoard(this);

            SetWhitesTurn();

            return OperationResult.Success;
        }

        public void SwitchTurn()
        {
            if (GetCurrentTurn().Player.Equals(WhitesPlayer)) SetBlacksTurn();
            else SetWhitesTurn();
        }

        public Turn GetCurrentTurn() => Turns.LastOrDefault();

        private void SetWhitesTurn() => Turns.Add(new Turn(WhitesPlayer).Start());
        private void SetBlacksTurn() => Turns.Add(new Turn(BlacksPlayer).Start());
    }
}
