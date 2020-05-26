using ChessGame.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Api.Dtos.Game
{
    public class TurnDto
    {
        public PlayerDto Player { get; set; }

        public DateTime StartedTimeUtc { get; set; }

        public MovementDto Movement { get; set; }

        public bool IsCompleted { get; set; }

        public static TurnDto Cast(Turn turn) => new TurnDto
        {
            IsCompleted = turn.IsCompleted,
            Movement = turn.IsCompleted ? MovementDto.Cast(turn.Movement) : null,
            Player = PlayerDto.Cast(turn.Player, ignorePieces: true),
            StartedTimeUtc = turn.StartedTimeUtc
        };
    }
}
