using ChessGame.Domain.Entities;
using ChessGame.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects.Specifications
{
    public class IsLegalMovement : ISpecification<PieceMovement>
    {
        private readonly Board _board;

        public static IsLegalMovement Create(Board board) => new IsLegalMovement(board);

        private IsLegalMovement(Board board)
        {
            this._board = board;
        }

        public bool IsSatisfied(PieceMovement candidate)
        {
            throw new NotImplementedException("Implement tests.");

            var isMovementAllowedSpecification = IsMovementAllowed.Create(_board);
            var isMovementLandingOnEmptyOrOponentColor = IsMovementLandingOnEmptyOrOponentColor.Create(_board);

            return SpecificationEvaluator.And(candidate,
                                              isMovementAllowedSpecification,
                                              isMovementLandingOnEmptyOrOponentColor);
        }
    }
}
