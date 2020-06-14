using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessGame.Api.Arguments;
using ChessGame.Api.Hubs;
using ChessGame.Application.Dtos.Results;
using ChessGame.Application.Services;
using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChessGame.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameService _gameService;
        private readonly IHubContext<GameHub> _hub;

        public GamesController(GameService gameService, IHubContext<GameHub> hub)
        {
            this._gameService = gameService;
            this._hub = hub;
        }

        [HttpGet]
        public IEnumerable<Game> GetList()
        {
            return _gameService.GetGames();
        }

        // POST: api/game/prepare
        [HttpPost("prepare")]
        public ActionResult<Guid> Prepare()
        {
            Guid gameId = _gameService.PrepareGame();
            return gameId;
        }

        [HttpPost("{gameId}/addplayer")]
        public async Task<ActionResult<Guid>> AddPlayer(Guid gameId, [FromBody] string playerName)
        {
            Game game = _gameService.GetGame(gameId);
            if (game.CanStart)
                return Guid.Empty;

            Guid playerId = game.AddPlayer(playerName) ?? Guid.Empty;

            if (game.CanStart)
            {
                await _hub.Clients.All.SendAsync("RefreshGame");
            }

            return playerId;
        }

        // POST: api/game/start
        [HttpPost("start")]
        public ActionResult<Guid> Start([FromBody] StartGameArguments arguments)
        {
            Guid gameId = _gameService.StartNewGame(arguments.Player1, arguments.Player2);
            return gameId;
        }

        // GET api/game/00000000-0000-0000-0000-000000000000
        [HttpGet("{gameId}")]
        public ActionResult<Game> GetGameState(Guid gameId)
        {
            Game game = _gameService.GetGame(gameId);
            if (game == null)
                return NotFound($"Game with id {gameId} was not found.");

            return game;
        }

        // POST: api/game/move
        [HttpPost("{gameId}/move")]
        public async Task<ActionResult<TurnLog>> Move(Guid gameId, [FromBody] MoveArguments arguments)
        {
            MakeMoveResult makeMoveResult = _gameService.MakeMove(gameId, Position.Create(arguments.Origin), Position.Create(arguments.Destination));
            if (!makeMoveResult.Success)
                return BadRequest(makeMoveResult.FailReason);

            await _hub.Clients.All.SendAsync("RefreshGame");

            return makeMoveResult.TurnLog; 
        }
    }
}
