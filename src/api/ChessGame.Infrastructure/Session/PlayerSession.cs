using ChessGame.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Infrastructure.Session
{
    public class PlayerSession : IPlayerSession
    {
        public PlayerSession(IHttpContextAccessor httpContextAccessor)
        {
            StringValues? headerValue = httpContextAccessor.HttpContext?.Request?.Headers[nameof(PlayerId)];
            if (headerValue.HasValue && Guid.TryParse(headerValue.Value.ToString(), out Guid playerId))
                PlayerId = playerId;
        }

        public Guid? PlayerId { get; set; }
    }
}
