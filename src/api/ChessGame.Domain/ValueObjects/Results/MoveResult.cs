using ChessGame.Domain.Entitites.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects.Results
{
    public class MoveResult
    {
        public IPiece Piece { get; set; }

        public IPiece KilledPiece { get; set; }

        public IPiece SwappedPiece { get; set; }

        public static MoveResult Default() => new MoveResult();
    }
}
