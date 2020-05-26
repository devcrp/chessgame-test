using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Api.Dtos.Game
{
    public class PieceDto
    {
        public Guid Id { get; set; }

        public Position Position { get; set; }

        public string Color { get; set; }

        public string Type { get; set; }

        public static PieceDto Cast(IPiece piece) => new PieceDto
        {
            Id = piece.Id,
            Color = piece.Color == Domain.ValueObjects.Color.Black ? "black" : "white",
            Position = piece.Position,
            Type = piece.Type
        };

    }
}
