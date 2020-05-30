using ChessGame.Application.Results;
using ChessGame.Domain.Entitites;
using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Application.Services.Validators
{
    public static class MoveValidatorService
    {
        public static OperationResult<MoveValidationResult> Validate(Game game, Guid pieceId, Position destination)
        {
            var result = new MoveValidationResult();

            IPiece piece = game.Board.GetPieces().SingleOrDefault(piece => piece.Id == pieceId);
            if (piece == null || !game.GetCurrentTurn().Player.Pieces.Contains(piece))
            {
                return OperationResult<MoveValidationResult>.Fail($"This piece is not in the board for the current player.");
            }

            IPiece pieceAtDestination = game.Board.GetPieces().SingleOrDefault(piece => piece.Position.Key == destination.Key);

            OperationResult positionAllowedOperation = piece.IsPositionAllowed(destination, pieceAtDestination);
            if (!positionAllowedOperation.IsSuccessful)
                return new OperationResult<MoveValidationResult>(positionAllowedOperation);

            if (pieceAtDestination != null && pieceAtDestination.Color != piece.Color)
                result.PieceKilled = pieceAtDestination;

            return new OperationResult<MoveValidationResult>(result);
        }
    }
}
