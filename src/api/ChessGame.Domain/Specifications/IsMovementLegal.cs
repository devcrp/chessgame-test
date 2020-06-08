using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Specifications
{
    public class IsMovementLegal : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static IsMovementLegal Create(Board board) => new IsMovementLegal(board);

        private IsMovementLegal(Board board)
        {
            this._board = board;
        }

        public bool IsSatisfied(PieceMovement candidate)
        {
            var isMovementAllowedSpecification = IsMovementAllowed.Create(_board);
            var isMovementLandingOnEmptyOrOponentColorSpecification = IsMovementLandingOnEmptyOrOponentColor.Create(_board);

            return SpecificationEvaluator.And(candidate,
                                              isMovementAllowedSpecification,
                                              isMovementLandingOnEmptyOrOponentColorSpecification);
        }
    }
}
