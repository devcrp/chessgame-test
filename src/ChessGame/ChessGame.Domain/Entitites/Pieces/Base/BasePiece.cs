using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entitites.Pieces.Base
{
    public class BasePiece
    {
        public BasePiece(Player player, Position position)
        {
            Player = player;
            Position = position;
        }
        
        public Player Player { get; set; }

        public Position Position { get; set; }

        public virtual bool Move(Position destination)
        {
            throw new NotImplementedException();
        }
    }
}
