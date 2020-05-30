using ChessGame.Domain.Entitites.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects.Results
{
    public class MoveValidationResult
    {
        public IPiece PieceKilled { get; internal set; }
    }
}
