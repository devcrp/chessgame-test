using ChessGame.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Api.Controllers.Base
{
    public class BaseChessController : ControllerBase
    {
        protected ActionResult<OperationResult<T>> Result<T>(OperationResult<T> result)
        {
            if (!result.IsSuccessful)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
