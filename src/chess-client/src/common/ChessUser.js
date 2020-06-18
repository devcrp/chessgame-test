const ChessUser = {
  getId: () => {
    const playerId = localStorage.getItem("chess-game-playerid");
    if (!playerId) return null;

    return playerId;
  },

  setId: (playerId) => {
    localStorage.setItem("chess-game-playerid", playerId);
  },

  getName: () => {
    const playerName = localStorage.getItem("chess-game-playername");
    if (!playerName) return null;

    return playerName;
  },

  setName: (playerName) => {
    localStorage.setItem("chess-game-playername", playerName);
  },
};

export default ChessUser;
