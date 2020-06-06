using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.Services
{
    public static class PositionComparer
    {
        public static int FileDistanceAbs(Position left, Position right) => Math.Abs(left.FileIndex - right.FileIndex);

        public static int RankDistanceAbs(Position left, Position right) => Math.Abs(left.RankIndex - right.RankIndex);

        public static int FileDistance(Position left, Position right) => left.FileIndex - right.FileIndex;

        public static int RankDistance(Position left, Position right) => left.RankIndex - right.RankIndex;

    }
}
