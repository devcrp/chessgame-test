using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessGame.Api.Controllers.Base;
using ChessGame.Api.Dtos.Game;
using ChessGame.Application.Services;
using ChessGame.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessGame.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : BaseChessController
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            this._gameService = gameService;
        }

        // POST: api/game/start
        [HttpPost("start")]
        public ActionResult<OperationResult<Guid>> Start([FromBody] StartGameArguments arguments)
        {
            OperationResult<Guid> operationResult = _gameService.StartNewGame(arguments.Player1, arguments.Player2);
            return Result(operationResult);
        }
    }
}
