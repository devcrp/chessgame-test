using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Api.Dtos.Game
{
    public class StartGameArguments
    {
        public string Player1 { get; set; }
        public string Player2 { get; set; }
    }
}
