using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Api.Dtos.Game
{
    public class GameDto
    {
        public Guid Id { get; set; }

        public DateTime StartedTimeUtc { get; set; }

        public PlayerDto WhitesPlayer { get; set; }

        public PlayerDto BlacksPlayer { get; set; }

        public List<TurnDto> Turns { get; set; }

        public TurnDto CurrentTurn { get; set; }
    }
}
