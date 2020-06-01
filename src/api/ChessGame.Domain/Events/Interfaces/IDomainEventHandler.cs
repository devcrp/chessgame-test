using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Events.Interfaces
{
    public interface IDomainEventHandler
    {
        void Handle(object e);
    }
}
