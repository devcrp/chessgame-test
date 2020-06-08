using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessGame.Api.Arguments;
using ChessGame.Application.Dtos.Results;
using ChessGame.Application.Services;
using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessGame.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            this._gameService = gameService;
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
        public ActionResult<TurnLog> Move(Guid gameId, [FromBody] MoveArguments arguments)
        {
            MakeMoveResult makeMoveResult = _gameService.MakeMove(gameId, Position.Create(arguments.Origin), Position.Create(arguments.Destination));
            if (!makeMoveResult.Success)
                return BadRequest(makeMoveResult.FailReason);

            return makeMoveResult.TurnLog; 
        }
    }
}
