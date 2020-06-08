using ChessGame.Domain.Entitites.Interfaces;
using ChessGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Domain.Entitites
{
    public class Player
    {
        public Player(Game game, string name)
        {
            Game = game;
            Name = name;
        }

        public List<IPiece> Pieces { get; } = new List<IPiece>();

        public List<IPiece> DeadPieces { get; set; } = new List<IPiece>();

        public Game Game { get; }

        public string Name { get; }

        public OperationResult<IPiece> MakeMove(Guid pieceId, Position destination)
        {
            IPiece piece = this.Pieces.Single(piece => piece.Id == pieceId);
            return new OperationResult<IPiece>(piece, piece.Move(destination));
        }

        public OperationResult KillPiece(IPiece piece)
        {
            Pieces.Remove(piece);
            DeadPieces.Add(piece);

            return OperationResult.Success;
        }
    }
}
