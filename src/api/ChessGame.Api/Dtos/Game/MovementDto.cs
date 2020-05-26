using ChessGame.Domain.Entitites;
using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Api.Dtos.Game
{
    public class MovementDto
    {
        public PieceDto Piece { get; set; }

        public Position Origin { get; set; }

        public Position Destination { get; set; }

        public static MovementDto Cast(Movement movement) => new MovementDto
        {
            Piece = PieceDto.Cast(movement.Piece),
            Destination = movement?.Destination,
            Origin = movement?.Origin
        };
    }
}
