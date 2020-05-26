using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces.Base;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entitites.Pieces
{
    public class Pawn : BasePiece, IPiece
    {
        public Pawn(Player player, Position position) : base (player, position)
        {

        }

        public override bool Move(Position destination)
        {
            base.Position = destination;
            return true;
        }
    }
}
