using ChessGame.Domain.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Application.EventHandlers.Base
{
    public class Handler<T> where T : class, IDomainEvent
    {
        protected T GetEvent(object e) => e as T;
    }
}
