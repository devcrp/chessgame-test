using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Domain.ValueObjects
{
    public class Position
    {
        private static Dictionary<string, int> _toIndex = new Dictionary<string, int>
        {
            { "A", 1 },
            { "B", 2 },
            { "C", 3 },
            { "D", 4 },
            { "E", 5 },
            { "F", 6 },
            { "G", 7 },
            { "H", 8 }
        };

        private static Dictionary<int, string> _fromIndex = new Dictionary<int, string>
        {
            { 1, "A" },
            { 2, "B" },
            { 3, "C" },
            { 4, "D" },
            { 5, "E" },
            { 6, "F" },
            { 7, "G" },
            { 8, "H" }
        };

        public static Position Clone(Position copyFrom) => new Position(copyFrom.HPos, copyFrom.VPos);

        public static Position Parse(string key) => new Position(key[0].ToString(), int.Parse(key[1].ToString()));

        public Position(string hPos, int vPos)
        {
            VPos = vPos;
            HPos = _toIndex[hPos];
        }

        public Position(int hPos, int vPos)
        {
            VPos = vPos;
            HPos = hPos;
        }

        public int VPos { get; set; }

        public int HPos { get; set; }

        public string Key => $"{_fromIndex[HPos]}{VPos}";

        public bool VPosBetween(int pos1, int pos2) => VPos >= Math.Min(pos1, pos2) && VPos <= Math.Max(pos1, pos2);
        public bool HPosBetween(int pos1, int pos2) => HPos >= Math.Min(pos1, pos2) && HPos <= Math.Max(pos1, pos2);
    }
}
