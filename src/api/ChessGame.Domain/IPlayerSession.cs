using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain
{
    public interface IPlayerSession
    {
        Guid? PlayerId { get; set; }
    }
}
