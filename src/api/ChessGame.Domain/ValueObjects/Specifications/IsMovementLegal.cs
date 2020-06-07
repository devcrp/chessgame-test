using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects.Specifications
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
            var isMovementLandingOnEmptyOrOponentColor = IsMovementLandingOnEmptyOrOponentColor.Create(_board);

            return SpecificationEvaluator.And(candidate,
                                              isMovementAllowedSpecification,
                                              isMovementLandingOnEmptyOrOponentColor);
        }
    }
}
