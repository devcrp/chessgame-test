using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessGame.Api.Arguments;
using ChessGame.Api.Controllers.Base;
using ChessGame.Api.Dtos.Game;
using ChessGame.Application.Services;
using ChessGame.Domain.Entitites;
using ChessGame.Domain.Entitites.Interfaces;
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

        // GET api/game/00000000-0000-0000-0000-000000000000
        [HttpGet("{gameId}")]
        public ActionResult<OperationResult<GameDto>> GetGameState(Guid gameId)
        {
            OperationResult<Game> getGameOperation = _gameService.GetGame(gameId);
            OperationResult<GameDto> response = new OperationResult<GameDto>(getGameOperation);
            if (getGameOperation.IsSuccessful)
            {
                Game game = getGameOperation.Result;

                response.Result = new GameDto
                {
                    Id = game.Id,
                    StartedTimeUtc = game.StartedTimeUtc,
                    BlacksPlayer = PlayerDto.Cast(game.BlacksPlayer),
                    WhitesPlayer = PlayerDto.Cast(game.WhitesPlayer),
                    Turns = game.Turns.Select(turn => TurnDto.Cast(turn)).ToList(),
                    CurrentTurn = TurnDto.Cast(game.GetCurrentTurn())
                };
            }

            return Result(response);
        }

        // POST: api/game/move
        [HttpPost("{gameId}/move")]
        public ActionResult<OperationResult<PieceDto>> Move(Guid gameId, [FromBody] TurnMoveArguments arguments)
        {
            Position destination = Position.Parse(arguments.Destination);
            OperationResult<IPiece> makeMoveOperation = _gameService.MakeMove(gameId, arguments.PieceId, destination);
            if (!makeMoveOperation.IsSuccessful)
                return Result(new OperationResult<PieceDto>(makeMoveOperation));

            return Result(new OperationResult<PieceDto>(PieceDto.Cast(makeMoveOperation.Result), makeMoveOperation));
        }
    }
}
