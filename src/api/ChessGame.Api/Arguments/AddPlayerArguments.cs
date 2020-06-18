using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Api.Arguments
{
    public class AddPlayerArguments
    {
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; }
    }
}
