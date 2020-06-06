using ChessGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.ValueObjects
{
    public class Square
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
        public bool IsEmpty => Piece == null;
        public Piece Piece { get; set; }

        public static Square Create(string file, string rank) => new Square(file, rank);
        public static Square Create(int fileIndex, int rankIndex) => new Square(fileIndex, rankIndex);
        public static Square Create(string identifier)
        {
            return new Square(identifier[0].ToString(), identifier[1].ToString());
        }

        public static string ToIdentifier(int fileIndex, int rankIndex) => $"{POSITIONS_FILES[fileIndex]}{rankIndex}";

        private Square(int fileIndex, int rankIndex)
        {
            FileIndex = fileIndex;
            RankIndex = rankIndex;

            File = POSITIONS_FILES[fileIndex].ToString();
            Rank = rankIndex.ToString();
        }

        private Square(string file, string rank)
        {
            File = file;
            Rank = rank;

            FileIndex = FILES_POSITIONS[file[0]];
            RankIndex = int.Parse(rank);
        }

        public void LandPiece(Piece piece) => Piece = piece;
    }
}
