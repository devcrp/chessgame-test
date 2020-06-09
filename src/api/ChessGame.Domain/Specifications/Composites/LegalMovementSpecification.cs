using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using ChessGame.Domain.Specifications.Movements;
using ChessGame.Domain.Specifications.Pieces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Specifications.Composites
{
    public class LegalMovementSpecification : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static LegalMovementSpecification Create(Board board) => new LegalMovementSpecification(board);

        private LegalMovementSpecification(Board board)
        {
            this._board = board;
        }

        public bool IsSatisfied(PieceMovement candidate)
        {
            var isMovementAllowedSpecification = MovementValidator.ResolveSpecification(_board, candidate.Piece.Type);
            var isMovementLandingOnEmptyOrOponentColorSpecification = LandableMovementSpecification.Create(_board);

            return SpecificationEvaluator.And(candidate,
                                              isMovementAllowedSpecification,
                                              isMovementLandingOnEmptyOrOponentColorSpecification);
        }
    }
}
