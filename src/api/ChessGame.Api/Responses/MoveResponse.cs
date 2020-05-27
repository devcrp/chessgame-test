using ChessGame.Api.Dtos.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Api.Responses
{
    public class MoveResponse
    {
        public MoveResponse(PieceDto piece, TurnDto currentTurn)
        {
            Piece = piece;
            CurrentTurn = currentTurn;
        }

        public PieceDto Piece { get; set; }
        public TurnDto CurrentTurn { get; set; }
    }
}
