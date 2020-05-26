﻿using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.Entitites.Pieces.Base;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Entitites.Pieces
{
    public class Queen : BasePiece, IPiece
    {
        public Queen(Position position) : base(position)
        {

        }

        public string Type { get; set; } = "queen";

        public override OperationResult Move(Position destination)
        {
            base.Position = destination;
            return OperationResult.Success;
        }
    }
}
