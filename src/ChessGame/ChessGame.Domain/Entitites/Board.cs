using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Entitites
{
    public class Board
    {
        public Board(Game game)
        {
            Game = game;
            Size = new Size(8, 8);
        }

        public Size Size { get; }

        public Game Game { get; }

        public IEnumerable<IPiece> Pieces => Game.WhitesPlayer.Pieces.Union(Game.BlacksPlayer.Pieces);
    }
}
