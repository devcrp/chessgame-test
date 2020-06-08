using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.ValueObjects
{
    public class Position
    {
        const string FILES_IDENTIFIERS = "ABCDEFGH";
        private static Dictionary<char, int> FILES_POSITIONS = FILES_IDENTIFIERS.ToCharArray()
                                                                 .ToDictionary(x => x, x => FILES_IDENTIFIERS.IndexOf(x) + 1);
        private static Dictionary<int, char> POSITIONS_FILES = FILES_IDENTIFIERS.ToCharArray()
                                                                 .ToDictionary(x => FILES_IDENTIFIERS.IndexOf(x) + 1, x => x);

        public string Id => $"{File}{Rank}";
        public string File { get; }
        public string Rank { get; }
        public int FileIndex { get; }
        public int RankIndex { get; }

        public static Position Create(string file, string rank) => new Position(file, rank);
        public static Position Create(int fileIndex, int rankIndex) => new Position(fileIndex, rankIndex);
        public static Position Create(string identifier)
        {
            return new Position(identifier[0].ToString(), identifier[1].ToString());
        }

        public static string ToIdentifier(int fileIndex, int rankIndex) => $"{POSITIONS_FILES[fileIndex]}{rankIndex}";

        private Position(int fileIndex, int rankIndex)
        {
            File = POSITIONS_FILES[fileIndex].ToString();
            Rank = rankIndex.ToString();
            FileIndex = fileIndex;
            RankIndex = rankIndex;
        }

        private Position(string file, string rank)
        {
            File = file;
            Rank = rank;
            FileIndex = FILES_POSITIONS[file[0]];
            RankIndex = int.Parse(rank);
        }
    }
}
