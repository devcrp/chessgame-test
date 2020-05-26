using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Api.Arguments
{
    public class TurnMoveArguments
    {
        public Guid PieceId { get; set; }

        public string Destination { get; set; }
    }
}
