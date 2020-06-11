using ChessGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects
{
    public class CastlingEvaluationResult
    {
        public static CastlingEvaluationResult Create(Piece rook, Position from, Position to) => new CastlingEvaluationResult(rook, from, to);

        private CastlingEvaluationResult(Piece rook, Position from, Position to)
        {
            Rook = rook;
            From = from;
            To = to;
        }

        public Piece Rook { get; set; }

        public Position From { get; set; }

        public Position To { get; set; }
    }
}
