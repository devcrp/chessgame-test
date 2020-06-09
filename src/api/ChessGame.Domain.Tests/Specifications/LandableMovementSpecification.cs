using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using ChessGame.Domain.Specifications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.Domain.Specifications.Movements;

namespace ChessGame.Domain.Tests.Specifications
{
    public class LandableMovementSpecification
    {
        [Test]
        public void Move_Onto_Own_Color_Should_Not_Satisfy()
        {
            Board setupBoard = Board.CreateAndSetup();

            Domain.Specifications.Movements.LandableMovementSpecification specification = Domain.Specifications.Movements.LandableMovementSpecification.Create(setupBoard);
            bool isSatisfied = specification.IsSatisfied(PieceMovement.Create(setupBoard.GetSquare("A1").Piece,
                                                           Position.Create("A1"),
                                                           Position.Create("A2")));

            Assert.IsFalse(isSatisfied);
        }
    }
}
