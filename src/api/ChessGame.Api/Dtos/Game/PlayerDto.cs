using ChessGame.Domain.Entitites;
using ChessGame.Domain.Entitites.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Api.Dtos.Game
{
    public class PlayerDto
    {
        public string Name { get; set; }

        public List<PieceDto> Pieces { get; set; }

        public static PlayerDto Cast(Player player, bool ignorePieces = false) => new PlayerDto
        {
            Pieces = !ignorePieces ? player.Pieces.Select(piece => PieceDto.Cast(piece)).ToList() : null,
            Name = player.Name
        };
    }
}
