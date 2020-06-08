using ChessGame.Domain.Entities;
using ChessGame.Domain.ValueObjects;
using ChessGame.Domain.ValueObjects.Specifications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Tests.Specifications
{
    public class LegalMovementSpecificationTests
    {
        [Test]
        public void Move_Onto_Own_Color_Should_Not_Satisfy()
        {
            Board setupBoard = Board.CreateAndSetup();

            IsMovementLegal specification = IsMovementLegal.Create(setupBoard);
            bool isSatisfied = specification.IsSatisfied(PieceMovement.Create(setupBoard.GetSquare("A1").Piece,
                                                           Position.Create("A1"),
                                                           Position.Create("A2")));

            Assert.IsFalse(isSatisfied);
        }
    }
}
