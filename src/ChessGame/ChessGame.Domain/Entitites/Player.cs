using ChessGame.Domain.Entitites.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entitites
{
    public class Player
    {
        public Player(Game game, string name)
        {
            Game = game;
            Name = name;
        }

        public List<IPiece> Pieces { get; } = new List<IPiece>();

        public Game Game { get; }

        public string Name { get; }
    }
}
