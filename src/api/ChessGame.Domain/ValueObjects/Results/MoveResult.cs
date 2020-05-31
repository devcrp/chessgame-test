using ChessGame.Domain.Entitites.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects.Results
{
    public class MoveResult
    {
        public IPiece PieceKilled { get; set; }
    }
}
